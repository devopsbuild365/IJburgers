using System;
using System.ComponentModel.DataAnnotations;

namespace PostService.DTOs;

public class CreatePostDto
{
    [Required]
    public string Title { get; set; } 
    [Required]
    public string Content { get; set; }
    [Required]
    [Url]
    public string ImageUrl { get; set; }
}
