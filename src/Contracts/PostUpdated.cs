using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts;

public class PostUpdated
{
    public string Id { get; set; }
    public string Title { get; set; } 
    public string Content { get; set; }
    [Url]
    public string ImageUrl { get; set; }
}
