using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Persistence.Concrete;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Extensions
{
    public static class ServiceRegistrations
    {

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }


    }
}
