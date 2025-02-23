using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Project.Services.Abstractions;
using Project.Services.Concretes;


namespace Project.Services
{
    public static class ConfigurationServices
    {
        public static void AddBLService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ISliderItemService, SliderItemService>();
        }
    }
}
