using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.Application.Features.Messages.Endpoints
{
    public static class MessageEndpoints
    {

        public static void RegisterMessageEndpoints(this IEndpointRouteBuilder app)
        {
           
            var messages = app.MapGroup("/messages").WithTags("Messages");

            messages.MapPost("/", async (CreateMessageCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            messages.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetMessagesQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetMessageByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapPut("", async ( UpdateMessageCommand command, IMediator mediator) =>
            {
             
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveMessageCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
