
using BubberDinner.Api.Common.Errors;
using BubberDinner.Application;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// en vez de agregar la dependencia en cada "sub programa", genera un metodo en  Application
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)    ;
//control de errores con un filter

//builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
