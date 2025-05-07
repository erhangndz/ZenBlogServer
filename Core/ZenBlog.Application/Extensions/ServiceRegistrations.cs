using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ZenBlog.Application.Behaviors;

namespace ZenBlog.Application.Extensions
{
    public static class ServiceRegistrations
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
