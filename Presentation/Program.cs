using Application.Interfaces;
using Application.Models;
using Application.Services;

//using Infrastructure.SQL;
//using Infrastructure.SQL.Repository;
using Microsoft.EntityFrameworkCore;

using Infrastructure.SQLite;
using Infrastructure.SQLite.Repository;

//using Infrastructure.MongoDbDriver;
//using Infrastructure.MongoDbDriver.Repository;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPeopleService, PeoplePeopleService>();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb")); // SQL EFcore InMemory
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite()); // SQL EFcore InMemory

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/people", async (IPeopleService service) => await service.GetAllAsync());
app.MapPost("/people", async (IPeopleService service, AddPersonModel model) => await service.AddAsync(model));

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();



app.Run();

