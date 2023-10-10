using Microsoft.EntityFrameworkCore;
using Todo.API.Registrars.Abstractions;
using Todo.DataAccess.Context;

namespace Todo.API.Registrars.Implementations;

public class DbContextRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString(AppConfigurations.Constants.ConnectionString);
        builder.Services.AddDbContext<TodoDbContext>(optionBuilder =>
        {
            if (connectionString is null) throw new NullReferenceException();
            optionBuilder.UseSqlServer(connectionString);
        });
    }
}