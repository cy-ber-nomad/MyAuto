using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

public class AuthController : Controller
{
    // GET: /Auth/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Auth/Login
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Проверка логина и пароля (здесь должна быть ваша логика проверки)
        if (IsValidLogin(username, password))
        {
           // Установка флага аутентификации (допустим, через сессию или куки)
           // HttpContext.Session.SetString("IsAuthenticated", "true");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Ошибка входа
            ViewBag.ErrorMessage = "Неверный логин или пароль";
            return View();
        }
    }

    
    // GET: /Auth/Logout
   public IActionResult Logout()
    {
        // Очистка сеанса аутентификации пользователя
        HttpContext.SignOutAsync();

        // Перенаправление на страницу входа
        return RedirectToAction("Login");
    }

    
    private bool IsValidLogin(string username, string password)
    {
        // Здесь ваша проверка логина и пароля
        return (username == "admin" && password == "123456" || username == "raul" && password == "16");
    }
}
