using Microsoft.AspNetCore.Mvc;

namespace FortechTP3A2.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}