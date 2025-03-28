using KidsBooks.Data;
using KidsBooks.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookmarksRepository, BookmarksRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
{
    throw new InvalidOperationException("JWT Secret Key is missing or too short (must be at least 32 characters).");
}

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
