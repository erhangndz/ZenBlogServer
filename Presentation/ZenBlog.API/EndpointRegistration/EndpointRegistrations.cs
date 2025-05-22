using ZenBlog.Application.Features.Blogs.Endpoints;
using ZenBlog.Application.Features.Categories.Endpoints;
using ZenBlog.Application.Features.Comments.Endpoints;
using ZenBlog.Application.Features.ContactInfos.Endpoints;
using ZenBlog.Application.Features.Messages.Endpoints;
using ZenBlog.Application.Features.Socials.Endpoints;
using ZenBlog.Application.Features.SubComments.Endpoints;
using ZenBlog.Application.Features.Users.Endpoints;

namespace ZenBlog.API.EndpointRegistration
{
    public static class EndpointRegistrations
    {

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterCategoryEndpoints();
            app.RegisterBlogEndpoints();
            app.RegisterUserEndpoints();
            app.RegisterCommentEndpoints();
            app.RegisterSubCommentEndpoints();
            app.RegisterContactInfoEndpoints();
            app.RegisterMessageEndpoints();
            app.RegisterSocialEndpoints();

        }
    }
}
