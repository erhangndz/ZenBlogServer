using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.Endpoints
{
    public static class SocialEndpoints
    {

        public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/socials").WithTags("Socials");

            socials.MapPost("/", async (CreateSocialCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetSocialsQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            socials.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetSocialByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapPut("/", async (UpdateSocialCommand command, IMediator mediator) =>
            {

                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveSocialCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

        }

    }
}
