using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Queries;

namespace ZenBlog.Application.Features.Comments.Endpoints
{
    public static class CommentEndpoints
    {

        public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comments").WithTags("Comments");

            comments.MapGet("", 
               async (IMediator _mediator) =>
               {
                   var response = await _mediator.Send(new GetCommentsQuery());
                   return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
               });
        }

    }
}
