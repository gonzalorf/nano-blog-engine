using NanoBlogEngine.Application;
using NanoBlogEngine.Application.Configuration.Services;
using NanoBlogEngine.Infrastructure;
using NanoBlogEngine.Infrastructure.Security;
using NanoBlogEngine.WebApi.Middleware;
using NanoBlogEngine.WebApi.OptionsConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Clean Architecture
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UnhandledExceptionMiddleware>();

// Security
builder.Services.ConfigureOptions<JwtOptionsConfig>();
builder.Services.ConfigureOptions<JwtBearerOptionsConfig>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerOptionsConfig>();
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UnhandledExceptionMiddleware>();

app.MapControllers();

app.Run();