using System;
using AutoMapper;
using Contracts;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto, Post>();
        CreateMap<UpdatePostDto, Post>();
        CreateMap<PostDto, PostCreated>();
        CreateMap<Post, PostUpdated>();
    }
}