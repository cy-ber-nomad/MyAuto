using Microsoft.AspNetCore.Mvc;
using MyAuto.Models;

namespace MyAuto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}