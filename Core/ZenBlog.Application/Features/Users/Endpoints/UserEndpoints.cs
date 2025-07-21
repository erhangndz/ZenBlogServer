using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Application.Features.Users.Queries;

namespace ZenBlog.Application.Features.Users.Endpoints
{
    public static class UserEndpoints
    {

        public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users");

            users.MapPost("register",
                async (IMediator mediator, CreateUserCommand command) =>
                {
                    var response = await mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            users.MapPost("login",
                async (IMediator mediator, GetLoginQuery query) =>
                {
                    var response = await mediator.Send(query);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });

            
        }

    }
}
