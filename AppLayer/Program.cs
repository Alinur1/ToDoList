using BLL.Interfaces;
using BLL.Services;
using DAL.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Configure connection string
var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ToDoContext>(options =>
options.UseMySQL(connectionStrings));

// Add services to the container.

builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<ITaskList, TaskListService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
