using Microsoft.EntityFrameworkCore;
using System;
using WorkWhiz.Infraestructure;
using WorkWhiz.Infraestructure.Interfaces;
using WorkWhiz.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseInMemoryDatabase("WorkWhizDb");
});


// Register seeding service
builder.Services.AddTransient<SeedDataService>();

// Register other services
builder.Services.AddScoped<IPosterRepository, PosterRepository>();

var app = builder.Build();

// Run seeding logic at startup
using (var scope = app.Services.CreateScope())
{
    var seedService = scope.ServiceProvider.GetRequiredService<SeedDataService>();
    await seedService.SeedAsync();  
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
