using Microsoft.AspNetCore.Mvc;
using MyAuto.Models;

namespace MyAuto.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
