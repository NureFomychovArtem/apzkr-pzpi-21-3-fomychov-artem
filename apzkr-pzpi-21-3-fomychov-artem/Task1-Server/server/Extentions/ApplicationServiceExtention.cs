using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace server.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this
            IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options => options.AddPolicy(name: "EduCheckOrigins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                }));

            return services;
        }
    }
}