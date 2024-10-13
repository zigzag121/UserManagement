using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Repositories;
using UserManagement.Data;
using UserManagement.Services.Interfaces;
using UserManagement.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();

var app = builder.Build();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();