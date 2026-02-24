using System;
using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Post>()
            .Key(x => x.Title, KeyType.Text)
            .Key(x => x.Content, KeyType.Text)
            .Key(x => x.Author, KeyType.Text)
            .CreateAsync();      

        var count = await DB.CountAsync<Post>();

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<PostSvcHttpClient>();

        var posts = await httpClient.GetPostsForSearchDb();

        Console.WriteLine("returned posts count: " + posts.Count);

        if (posts.Count > 0) await DB.SaveAsync(posts);

        // if (count == 0)
        // {
        //     Console.WriteLine("Seeding initial data...");

        //     var postData = await File.ReadAllTextAsync("Data/posts.json");

        //     var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        //     var posts = JsonSerializer.Deserialize<List<Post>>(postData, options);   

        //     await DB.SaveAsync(posts!);         
        // }
    }
}
