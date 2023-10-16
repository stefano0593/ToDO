using Microsoft.AspNetCore.Identity;
using Todo.API.Registrars.Abstractions;
using Todo.DataAccess.Context;

namespace Todo.API.Registrars.Implementations;

public class IdentityCoreRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<TodoDbContext>()
            .AddDefaultTokenProviders();
    }
}