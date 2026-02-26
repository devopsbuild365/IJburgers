using System;
using Contracts;
using MassTransit;

namespace PostService.Consumers;

public class PostCreatedFaultConsumer : IConsumer<Fault<PostCreated>>
{
    public async Task Consume(ConsumeContext<Fault<PostCreated>> context)
    {
        
        Console.WriteLine("--> Consuming faulty creation");

        var exception = context.Message.Exceptions.First();

        if (exception.ExceptionType == "System.ArgumentException")
        {
            context.Message.Message.Title = "test";
            await context.Publish(context.Message.Message);
        }
        else
        {
            Console.WriteLine("Not an argument exception - update error dashboard somewhere");
        }
    }
}
