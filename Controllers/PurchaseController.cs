using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAuto.Models;

public class PurchaseController : Controller
{
    private readonly ApplicationDbContext _context;

    public PurchaseController(ApplicationDbContext context)
    {
        _context = context;
    }

    

    public IActionResult Index()
    {
        
        return View(); 
    }
}
