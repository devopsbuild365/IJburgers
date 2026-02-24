using System;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Services;

public class PostSvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public PostSvcHttpClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<List<Post>> GetPostsForSearchDb()
    {
        var lastUpdated = await DB.Find<Post, string>()
            .Sort(x => x.Descending(x => x.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        return await _httpClient.GetFromJsonAsync<List<Post>>(_config["PostServiceUrl"] 
            + "/api/posts?date=" + lastUpdated);        
    }
}
