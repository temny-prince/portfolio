using DarkSwagger;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastruct.Data;
using TestingPlatform.Infrastruct.Repositories;
using TestingPlatform.Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Исправленный AutoMapper (Вариант А)
builder.Services.AddAutoMapper(cfg => { }, typeof(GroupProfile).Assembly);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDarkSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();