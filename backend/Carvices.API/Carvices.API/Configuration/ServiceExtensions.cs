using Carvices.BLL.Interfaces;
using Carvices.BLL.Realization;
using Carvices.DAL.Interfaces;
using Carvices.DAL.Realization;

namespace Carvices.API.Configuration
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IServiceActionRepository, ServiceActionRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceActionService, ServiceActionService>();
        }
    }
}
