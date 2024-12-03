using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TfdThreeTier.DataAccess.Data;
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
        throw new InvalidOperationException("connection string not found")));


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
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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

app.UseAuthorization();

app.MapControllers();

app.Run();
