using BLL.Interfaces;
using BLL.Services;
using DAL.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure connection string
var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseMySQL(connectionStrings));

// Add services to the container.
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<ITaskList, TaskListService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React App
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
