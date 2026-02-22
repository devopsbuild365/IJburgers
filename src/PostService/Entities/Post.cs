using System;
using System.ComponentModel.DataAnnotations;

namespace PostService.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Content { get; set; }
    [Url]
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string Author { get; set; } 
    public int Views { get; set; } = 0;
}
