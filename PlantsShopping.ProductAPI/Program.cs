using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantsShopping.ProductAPI.Config;
using PlantsShopping.ProductAPI.Model.Context;
using PlantsShopping.ProductAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration
    .GetConnectionString("PostgreConnection");

builder.Services.AddDbContext<PostgreContext>(options =>
    options.UseNpgsql(connection));

// AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IPlantRepository, PlantRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();