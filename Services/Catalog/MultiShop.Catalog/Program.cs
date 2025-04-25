using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

// Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// MongoDB Settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// MongoDB Client
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return new MongoClient(settings.ConnectionString);
});

// MongoDB Database
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return client.GetDatabase(settings.DatabaseName);
});

// MongoDB Collections
builder.Services.AddSingleton<IMongoCollection<Category>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return database.GetCollection<Category>(settings.CategoryCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Product>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return database.GetCollection<Product>(settings.ProductCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<ProductDetail>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return database.GetCollection<ProductDetail>(settings.ProductDetailCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<ProductImage>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return database.GetCollection<ProductImage>(settings.ProductImageCollectionName);
});

// Add API Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MultiShop.Catalog", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiShop.Catalog v1");
        c.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();