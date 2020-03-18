using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                            new Info {
                                Title = "Api Consulta Placa",
                                Description = "Esta API serve para a consulta de veiculos a partir da placa.",
                                Contact = new Contact() { Name = "Kaique Albuquerque", Email = "kaiquealbuquerque@hotmail.com" },
                                Version = "1.0"
                            }); 
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Consulta Placa");
            });

            return app;
        }
    }
}
