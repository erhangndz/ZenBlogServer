using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints
{
    public static class ContactInfoEndpoints
    {


        public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/contactInfos").WithTags("ContactInfos");

            contactInfos.MapGet("", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetContactInfosQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            contactInfos.MapGet("{id}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new GetContactInfoByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapPost("", async (IMediator mediator, CreateContactInfoCommand command) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapPut("", async (IMediator mediator, UpdateContactInfoCommand command) =>
            {
              
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            contactInfos.MapDelete("{id}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new RemoveContactInfoCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
