using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SecondAPI.Model;
using SecondAPI.service;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");

var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionStringBuilder = new SqlConnectionStringBuilder(connectionStringTemplate)
{
    Password = dbPassword
};

var finalConnectionString = connectionStringBuilder.ConnectionString;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(finalConnectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IBooksService, BooksService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
