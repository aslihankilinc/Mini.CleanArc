using AutoMapper;
using FluentValidation; // Add this using directive  
using FluentValidation.AspNetCore; // Add this using directive  
using Microsoft.EntityFrameworkCore;
using Mini.CleanArc.Core.Application.IContract;
using Mini.CleanArc.Infrastructure;
using Mini.CleanArc.Infrastructure.Extensions;
using Mini.CleanArc.Infrastructure.Persistence;
using Mini.CleanArc.Infrastructure.Service;
using Mini.CleanArc.WebApi.Middleware;
using System;

var builder = WebApplication.CreateBuilder(args);
//DbConnection  
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite(
       builder.Configuration.GetConnectionString("DefaultConnection"),
       b => b.MigrationsAssembly("Mini.CleanArc.Infrastructure")
   )
);
// Add services to the container.  
//Dependency Injection  
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Add FluentValidation services  
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
// Ensure FluentValidation is properly configured  
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper  
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//migration  
app.ApplyMigrations();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
