using ZenBlog.Application.Features.Blogs.Endpoints;
using ZenBlog.Application.Features.Categories.Endpoints;
using ZenBlog.Application.Features.Comments.Endpoints;
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
            
        }
    }
}
