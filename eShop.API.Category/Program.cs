using eShop.API.DTO.DTOs;
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
           .AllowAnyMethod());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

RegisterEndpoints();

/************************
 ** CORS Configuration **
 ************************/
app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterEndpoints()
{
    app.AddEndPoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
}