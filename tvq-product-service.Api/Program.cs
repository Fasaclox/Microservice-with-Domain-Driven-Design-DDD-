
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using tvq_product_service.Domain.App_Product.Interface;
using tvq_product_service.Infrastructure.App_Product.Context;
using tvq_product_service.Infrastructure.App_Product.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Product_Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProduct_Repository, Product_Repository>();
builder.Services.AddScoped<IProduct_Category_Repository, Product_Category_Repository>();
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
