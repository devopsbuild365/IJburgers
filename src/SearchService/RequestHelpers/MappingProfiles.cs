using System;
using AutoMapper;
using Contracts;
using SearchService.Entities;

namespace SearchService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PostCreated, Post>();
    }
}
