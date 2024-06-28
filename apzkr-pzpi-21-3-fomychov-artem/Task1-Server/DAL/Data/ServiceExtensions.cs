using DAL.Repository;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Data
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureDataAccessLayer(
            this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}