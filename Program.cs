using Microsoft.EntityFrameworkCore;
using MovieManagement.API.Application.Services;
using MovieManagement.API.Infrastructure;
using MovieManagement.API.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' was not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();//Όταν ένας constructor ζητήσει IMovieRepository, το DI Container δημιουργεί ή παρέχει ένα αντικείμενο MovieRepository
builder.Services.AddScoped<IMovieService, MovieService>(); //Όταν κάποιος ζητήσει IMovieService(πχ κάποιος Constructor), δημιούργησε και δώσε του ένα αντικείμενο MovieService

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
