using Microsoft.EntityFrameworkCore;
using ToDoList.DbAccess;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ToDoContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
