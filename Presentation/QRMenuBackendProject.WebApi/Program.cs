using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.FavoriteRestaurantInterface;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using QRMenuBackendProject.Application.Interfaces.AccountInterface;
using QRMenuBackendProject.Application.Services;
using QRMenuBackendProject.Application.Tools;
using QRMenuBackendProject.Persistance.Context;
using QRMenuBackendProject.Persistance.Repositories;
using QRMenuBackendProject.Persistance.Repositories.FavoriteRestaurantRepositories;
using QRMenuBackendProject.Persistance.Repositories.InvoiceRepositories;
using QRMenuBackendProject.Persistance.Repositories.OrderItemsRepositories;
using QRMenuBackendProject.Persistance.Repositories.OrdersRepositories;
using QRMenuBackendProject.Persistance.Repositories.AccountRepositories;
using System.Text;
using QRMenuBackendProject.Application.Interfaces.CategoriesInterface;
using QRMenuBackendProject.Persistance.Repositories.CategoriesRepositories;
using QRMenuBackendProject.Application.Interfaces.MenuInterface;
using QRMenuBackendProject.Persistance.Repositories.MenuRepositories;
using QRMenuBackendProject.Persistance.Repositories.MenuRepositories.MenuItemsRepositories;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;
using QRMenuBackendProject.Persistance.Repositories.RestaurantRepositories;
using QRMenuBackendProject.Application.Interfaces.RestaurantInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

// Add services to the container.
builder.Services.AddScoped<QRMenuBackendProjectContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IFavoriteRestaurantRepository, FavoriteRestaurantRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuItemsRepository, MenuItemRepository>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QRMenuBackendProjectContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
