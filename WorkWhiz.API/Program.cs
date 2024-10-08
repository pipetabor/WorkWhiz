using Microsoft.EntityFrameworkCore;
using WorkWhiz.Infraestructure;
using WorkWhiz.Infraestructure.Interfaces;
using WorkWhiz.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(WorkWhiz.Core.MappingProfiles.MappingProfile));

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseInMemoryDatabase("WorkWhizDb");
});


// Register seeding service
builder.Services.AddTransient<SeedDataService>();

// Register other services
builder.Services.AddScoped<IPosterRepository, PosterRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAngularApp");

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
