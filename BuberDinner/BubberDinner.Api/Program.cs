using BubberDinner.Api.Filters;
using BubberDinner.Api.Middelware;
using BubberDinner.Application;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// en vez de agregar la dependencia en cada "sub programa", genera un metodo en  Application
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)    ;
//control de errores con un filter
//builder.Services.AddControllers(options=> options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddControllers();

var app = builder.Build();
//control de errores con un middelware
//app.UseMiddleware<ErrorHandlingMiddelware>();
//activar el manejado de errores con un controlador
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
