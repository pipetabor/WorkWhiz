using Microsoft.EntityFrameworkCore;
using System;
using WorkWhiz.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseInMemoryDatabase("WorkWhizDb");
});

// Register RequestDelegate
builder.Services.AddSingleton<RequestDelegate>(next => context => Task.CompletedTask);

// Register seeding service or middleware (replace with appropriate type)
builder.Services.AddTransient<SeedDataMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
