using MediatR;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Queries;

namespace ZenBlog.API.Endpoints
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

        }

    }
}
