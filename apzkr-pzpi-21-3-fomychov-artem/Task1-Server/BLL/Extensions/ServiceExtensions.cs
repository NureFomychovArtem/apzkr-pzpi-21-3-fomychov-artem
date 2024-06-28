using BLL.Mappings;
using BLL.Service;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace BLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureBusinessLayerServices(
           this IServiceCollection services,
            IConfiguration config)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.ConfigureAutomapper();
            return services;
        }

        private static IServiceCollection ConfigureAutomapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            return services;
        }
    }
}