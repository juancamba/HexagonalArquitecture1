using BubberDinner.Application;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// en vez de agregar la dependencia en cada "sub programa", genera un metodo en  Application
builder.Services
    .AddApplication()
    .AddInfrastructure()
    ;

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
