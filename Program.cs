using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAuto.Models;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов
builder.Services.AddControllersWithViews();

// Настройка подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка HttpClient с отключенной проверкой SSL-сертификата
builder.Services.AddTransient<HttpClientHandler>(sp =>
{
    return new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
    };
});

var app = builder.Build();

// Использование middleware для обслуживания статических файлов
app.UseStaticFiles();

app.UseRouting();

// Настройка middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Настройка обработки ошибок в продукции
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//маршрут для контроллера PurchaseController
app.MapControllerRoute(
    name: "purchase",
    pattern: "Purchase/{action=Index}/{id?}",
    defaults: new { controller = "Purchase", action = "Index" });


// Настройка маршрутов для контроллеров
app.MapControllerRoute(
    name: "car",
    pattern: "Car/{action=Index}/{id?}",
    defaults: new { controller = "Car" });

app.MapControllerRoute(
    name: "purchase",
    pattern: "Purchase/{action=Index}/{id?}",
    defaults: new { controller = "Purchase" });

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}"); // Задаем страницу авторизации по умолчанию

app.MapControllerRoute(
    name: "home",
    pattern: "Home/Index", // Главная страница после успешной авторизации
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
        name: "carInfo",
        pattern: "CarController/GetCarInfo/{carId}",
        defaults: new { controller = "CarController", action = "GetCarInfo" });


app.Run();
