using Todo.API.AppConfigurations;
using Todo.API.Registrars.Abstractions;
using Todo.Application.Settings;

namespace Todo.API.Registrars.Implementations;

public class OptionsRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(
            builder.Configuration.GetSection(Constants.JwtSettings));

        builder.Services.Configure<RoleSettings>(
            builder.Configuration.GetSection(Constants.ApplicationRoles));
    }
}