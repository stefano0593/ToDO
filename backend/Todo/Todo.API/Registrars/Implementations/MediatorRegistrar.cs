using MediatR;
using Todo.API.Registrars.Abstractions;
using Todo.Application.Accounts;

namespace Todo.API.Registrars.Implementations;

public class MediatorRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(SignupAsUserCommand));
    }
}