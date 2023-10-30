using Todo.API.AppConfigurations;
using Todo.API.Registrars;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(typeof(Program));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(Constants.CorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();