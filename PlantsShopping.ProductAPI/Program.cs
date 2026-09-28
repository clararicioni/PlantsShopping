using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantsShopping.ProductAPI.Config;
using PlantsShopping.ProductAPI.Model.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration
    .GetConnectionString("PostgreConnection");

builder.Services.AddDbContext<PostgreContext>(options =>
    options.UseNpgsql(connection));

var app = builder.Build();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();