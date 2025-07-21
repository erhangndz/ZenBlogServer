using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;

namespace ZenBlog.Application.Features.Blogs.Endpoints
{
    public static class BlogEndpoints
    {

        public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
        {
            var blogs = app.MapGroup("/blogs").WithTags("Blogs");

            blogs.MapGet(string.Empty,
                async (IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetBlogsQuery());

                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                }).RequireAuthorization();


            blogs.MapPost(string.Empty, 
                async (CreateBlogCommand command,IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            blogs.MapGet("{id}",
                async (Guid id, IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetBlogByIdQuery(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            blogs.MapPut(string.Empty,
                async (UpdateBlogCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            blogs.MapDelete("{id}",
                async (Guid id,IMediator mediator) =>
                {
                    var response = await mediator.Send(new RemoveBlogCommand(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            blogs.MapGet("byCategoryId/{categoryId}",
                async (Guid categoryId, IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetBlogsByCategoryIdQuery(categoryId));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });
        }
    }
}
