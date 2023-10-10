﻿using Todo.API.Registrars.Abstractions;

namespace Todo.API.Registrars.Implementations;

public class ApiRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSwaggerGen();
    }
}