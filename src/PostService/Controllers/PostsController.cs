using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public PostsController(DataContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts(string date)
    {
        var query = _context.Posts.OrderByDescending(p => p.CreatedAt).AsQueryable();

        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(p => p.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        return _mapper.Map<PostDto>(post);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto createPostDto)
    {
        var post = _mapper.Map<Post>(createPostDto);

        post.Author = User.Identity?.Name ?? throw new InvalidOperationException("User not found");

        _context.Posts.Add(post);        

        var newPost = _mapper.Map<PostDto>(post);

        await _publishEndpoint.Publish(_mapper.Map<PostCreated>(newPost));   
        
        var result = await _context.SaveChangesAsync() > 0;        

        if (!result) return BadRequest("could not save changes to the database");

        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, newPost);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        if (post.Author != User.Identity?.Name) return Forbid();

        post.Title = updatePostDto.Title ?? post.Title;
        post.Content = updatePostDto.Content ?? post.Content;
        post.ImageUrl = updatePostDto.ImageUrl ?? post.ImageUrl;

        await _publishEndpoint.Publish(_mapper.Map<PostUpdated>(post));   

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Could not update the post");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null) return NotFound();

        if (post.Author != User.Identity?.Name) return Forbid();
        _context.Posts.Remove(post);

        await _publishEndpoint.Publish<PostDeleted>(new {Id = post.Id.ToString()});

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Could not delete the post");
    }
}
