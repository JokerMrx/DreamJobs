using DreamJobs.Account.API.Constants;
using DreamJobs.Account.Application.Interfaces.Services;
using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Infrastructure.Configs;
using DreamJobs.Account.Infrastructure.Context;
using DreamJobs.Account.Infrastructure.Options;
using DreamJobs.Account.Infrastructure.Providers;
using DreamJobs.Account.Infrastructure.Repositories;
using DreamJobs.Account.Infrastructure.Services;
using DreamJobs.Account.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

EnvReader.Load(".env");
var mapper = MapperConfig.RegisterMapperConfig().CreateMapper();

if (string.IsNullOrEmpty(Database.DatabaseUrl))
{
    throw new Exception("Please set environment variable 'DATABASE_URL'");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(options =>
{
    options.SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? string.Empty;
    options.AccessTokenExpiresInMinutes =
        int.TryParse(Environment.GetEnvironmentVariable("ACCESS_TOKEN_EXPIRESIN_MINUTES"),
            out var accessTokenExpiresInMinutes)
            ? accessTokenExpiresInMinutes
            : Token.AccessTokenExpirationMinutes;
    options.RefreshTokenExpiresInMinutes =
        int.TryParse(Environment.GetEnvironmentVariable("REFRESH_TOKEN_EXPIRESIN_MINUTES"),
            out var refreshTokenExpiresInMinutes)
            ? refreshTokenExpiresInMinutes
            : Token.RefreshTokenExpirationMinutes;
});

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(Database.DatabaseUrl); });
builder.Services.AddSingleton<JwtOptions>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<IEmployeeProfileRepository, EmployeeProfileRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

app.Run();