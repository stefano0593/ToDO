using Todo.API.Registrars.Abstractions;

namespace Todo.API.Registrars.Implementations;

public class CorsRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(AppConfigurations.Constants.CorsPolicy,
                corsPolicyBuilder => corsPolicyBuilder
                .WithOrigins("localhost:3000")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader());
        });
    }
}