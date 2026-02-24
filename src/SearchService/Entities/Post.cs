using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Entities;

namespace SearchService.Entities;

public class Post : Entity
{
    public string Title { get; set; } 
    public string Content { get; set; }
    [Url]
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public string Author { get; set; }
    public int Views { get; set; }    
}