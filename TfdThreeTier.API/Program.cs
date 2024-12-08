using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Helper;
using TfdThreeTier.DataAccess.Interfaces;
using TfdThreeTier.DataAccess.Repositiories;
using TfdThreeTier.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Game connection string not found")));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection") ??
        throw new InvalidOperationException("User connection string not found")));

builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));
builder.Services.AddScoped<IUserAccount, UserAccountRepo>();


builder.Services.AddAuthorization();

builder.Services.AddScoped<ICharacterRepo, CharacterRepo>();
builder.Services.AddScoped<IComponentRepo, ComponentRepo>();
builder.Services.AddScoped<IMaterialRepo, MaterialRepo>();
builder.Services.AddScoped<IPatternRepo, PatternRepo>();
builder.Services.AddScoped<ICharacterPatternRepo, CharacterPatternRepo>();
builder.Services.AddScoped<ICharacterComponentRepo, CharacterComponentRepo>();
builder.Services.AddScoped<IComponentMaterialRepo, ComponentMaterialRepo>();
builder.Services.AddScoped<IComponentPatternRepo, ComponentPatternRepo>();
builder.Services.AddScoped<IMaterialPatternRepo, MaterialPatternRepo>();




builder.Logging.ClearProviders();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy =>
    {
        policy.WithOrigins("https://localhost:7136")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType);
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
