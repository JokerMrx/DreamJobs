using DreamJobs.Account.API.Constants;
using DreamJobs.Account.BL.Configs;
using DreamJobs.Account.BL.Context;
using DreamJobs.Account.BL.Options;
using DreamJobs.Account.BL.Providers;
using DreamJobs.Account.BL.Repositories;
using DreamJobs.Account.BL.Utils;
using DreamJobs.Account.Core.Repositories;
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
    options.ExpiresHours = int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRES_HOURS"), out var hours)
        ? hours
        : 12;
});

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(Database.DatabaseUrl); });
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<IEmployeeProfileRepository, EmployeeProfileRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

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