using AutoMapper;
using eShop.API.DTO;
using eShop.API.DTO.DTOs;
using eShop.API.Extensions.Extensions;
using eShop.Data.Context;
using eShop.Data.Enteties;
using eShop.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// SQL Server Service Registration
builder.Services.AddDbContext<EShopContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("EShopConnection")));

/**********
 ** CORS Cross-Origin Resource Sharing**
 **********/
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();

/************************
 ** CORS Configuration **
 ************************/
app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterEndpoints()
{
    app.AddEndPoint<Car, CarPostDTO, CarPutDTO, CarGetDTO>();//+ "{categoryId}"
    app.MapGet($"/api/productsbycategory/{{categoryId}}", async (IDbService db, int categoryId) =>
    {
        try
        {
            var result = await ((ProductDbService)db).GetProductsByCategoryAsync(categoryId);
            return Results.Ok(result);
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't get the requested products of type {typeof(Car).Name}.");
    });
}

void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, ProductDbService>();
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Car, CarPostDTO>().ReverseMap();
        cfg.CreateMap<Car, CarPutDTO>().ReverseMap();
        cfg.CreateMap<Car, CarGetDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandPostDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandPutDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandGetDTO>().ReverseMap();
        cfg.CreateMap<Fuel, FuelPostDTO>().ReverseMap();
        cfg.CreateMap<Fuel, FuelPutDTO>().ReverseMap();
        cfg.CreateMap<Fuel, FuelGetDTO>().ReverseMap();
        cfg.CreateMap<Colour, ColourPostDTO>().ReverseMap();
        cfg.CreateMap<Colour, ColourPutDTO>().ReverseMap();
        cfg.CreateMap<Colour, ColourGetDTO>().ReverseMap();
        cfg.CreateMap<CarCategory, CarCategoryDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}