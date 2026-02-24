using System;

namespace SearchService.RequestHelpers;

public class SearchParams
{
    public string SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set;} = 5;
    public string Author { get; set; }
    public string OrderBy { get; set; }
    public string FilterBy { get; set; }
}
