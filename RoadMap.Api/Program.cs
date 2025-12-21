using Carter;
using RoadMap.Api.Extension;
using RoadMap.Api.Middleware;
using RoadMap.Application;
using RoadMap.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, config) =>config.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplications();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddSingleton<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();
app.MapCarter();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RoadMap API v1");
    });

app.Run();
