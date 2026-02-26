using System;
using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class PostUpdatedConsumer : IConsumer<PostUpdated>
{
    private readonly IMapper _mapper;

    public PostUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<PostUpdated> context)
    {
        Console.WriteLine($"--> Consuming post updated: {context.Message.Id} - {context.Message.Title}");
        
        var post = _mapper.Map<Post>(context.Message);
        
        var result = await DB.Update<Post>()
            .MatchID(context.Message.Id)
            .ModifyOnly(p => new { p.Title, p.Content, p.ImageUrl }, post)
            .ExecuteAsync();  

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(PostUpdated), $"Failed to update post with id {context.Message.Id}");
    }
}