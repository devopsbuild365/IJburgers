using System;
using System.ComponentModel.DataAnnotations;

namespace PostService.DTOs;

public class UpdatePostDto
{
    public string Title { get; set; } 
    public string Content { get; set; }
    [Url]
    public string ImageUrl { get; set; }
}
