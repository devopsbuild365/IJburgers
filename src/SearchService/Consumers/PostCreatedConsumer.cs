using System;
using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class PostCreatedConsumer : IConsumer<PostCreated>
{
    private readonly IMapper _mapper;

    public PostCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<PostCreated> context)
    {
        Console.WriteLine($"--> Consuming post created: {context.Message.Id} - {context.Message.Title}");

        var post = _mapper.Map<Post>(context.Message); 

        if (post.Title.Contains("testtest", StringComparison.CurrentCultureIgnoreCase))
        {
            throw new ArgumentException("Test posts are not allowed.");
        }

        await post.SaveAsync();
    }
}