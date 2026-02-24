using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.RequestHelpers;

namespace SearchService.Controllers;

public class SearchController : ControllerBase
{
    [HttpGet]
    [Route("api/search")]
    public async Task<ActionResult<List<Post>>> SearchPost([FromQuery] SearchParams searchParams)
    {
        var query = DB.PagedSearch<Post, Post>();

        if (!string.IsNullOrEmpty(searchParams.SearchTerm))
        {
            var rx = new Regex(Regex.Escape(searchParams.SearchTerm), RegexOptions.IgnoreCase);

            query.Match(p =>
                rx.IsMatch(p.Title) ||
                rx.IsMatch(p.Content) ||
                rx.IsMatch(p.Author));
        }   

        query = searchParams.OrderBy switch
        {
            "old" => query.Sort(p => p.Ascending(p => p.CreatedAt)), 
            _ => query.Sort(p => p.Descending(p => p.CreatedAt))
        };

        if (!string.IsNullOrEmpty(searchParams.Author))
        {
            query = query.Match(p => p.Author == searchParams.Author);
        }

        query.PageNumber(searchParams.PageNumber).PageSize(searchParams.PageSize) ;

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            results = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}