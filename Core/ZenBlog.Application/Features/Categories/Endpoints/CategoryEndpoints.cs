using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Queries;

namespace ZenBlog.Application.Features.Categories.Endpoints
{
    public static class CategoryEndpoints
    {

        public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var categories = app.MapGroup("/categories").WithTags("Categories");


            categories.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCategoryQuery());

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            categories.MapPost(string.Empty,
                async (CreateCategoryCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            categories.MapGet("{id}",
                async (Guid id, IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetCategoryByIdQuery(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);

                });


            categories.MapPut(string.Empty,
                async (UpdateCategoryCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            categories.MapDelete("{id}",
                async (Guid id, IMediator mediator) =>
                {
                    var response = await mediator.Send(new RemoveCategoryCommand(id));
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

        }

    }
}
