using Project.Models;
using Project.Repository.Abstraction;
using Project.Repository.Implementation;

namespace Project.Repository
{
    public static class ConfigurationServices
    {
        public static void AddDLService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
            services.AddScoped<IRepository<Attendance>, Repository<Attendance>>();
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<SliderItem>, Repository<SliderItem>>();
        }
    }

}
