namespace Todo.API.Registrars.Abstractions;

public interface IWebApplicationBuilderRegistrar
{
    void RegisterServices(WebApplicationBuilder builder);
}