using Microsoft.EntityFrameworkCore;
using online_shop.Data;
using online_shop.Interfaces;
using online_shop.Models;
using online_shop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IBuyerRepository, BuyerRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IReceiptRepository, ReceiptRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL("server=localhost;database=online-shop2;username=root;password=;"));

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