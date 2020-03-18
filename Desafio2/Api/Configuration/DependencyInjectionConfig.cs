using Business.Interfaces;
using Business.Interfaces.Service;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddScoped<INotification, Notifier>();
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
