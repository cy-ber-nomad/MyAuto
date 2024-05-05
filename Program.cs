using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAuto.Models;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// ���������� ��������
builder.Services.AddControllersWithViews();

// ��������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� HttpClient � ����������� ��������� SSL-�����������
builder.Services.AddTransient<HttpClientHandler>(sp =>
{
    return new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
    };
});

var app = builder.Build();

// ������������� middleware ��� ������������ ����������� ������
app.UseStaticFiles();

app.UseRouting();

// ��������� middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // ��������� ��������� ������ � ���������
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//������� ��� ����������� PurchaseController
app.MapControllerRoute(
    name: "purchase",
    pattern: "Purchase/{action=Index}/{id?}",
    defaults: new { controller = "Purchase", action = "Index" });


// ��������� ��������� ��� ������������
app.MapControllerRoute(
    name: "car",
    pattern: "Car/{action=Index}/{id?}",
    defaults: new { controller = "Car" });

app.MapControllerRoute(
    name: "purchase",
    pattern: "Purchase/{action=Index}/{id?}",
    defaults: new { controller = "Purchase" });

// ��������� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}"); // ������ �������� ����������� �� ���������

app.MapControllerRoute(
    name: "home",
    pattern: "Home/Index", // ������� �������� ����� �������� �����������
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
        name: "carInfo",
        pattern: "CarController/GetCarInfo/{carId}",
        defaults: new { controller = "CarController", action = "GetCarInfo" });


app.Run();
