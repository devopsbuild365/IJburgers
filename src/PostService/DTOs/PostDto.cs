using System;
using System.ComponentModel.DataAnnotations;

namespace PostService.DTOs;

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Content { get; set; }
    [Url]
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public string Author { get; set; }
    public int Views { get; set; }
}
