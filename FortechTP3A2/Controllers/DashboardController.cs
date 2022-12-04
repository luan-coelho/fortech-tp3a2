using Microsoft.AspNetCore.Mvc;

namespace FortechTP3A2.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.username = HttpContext.Session.GetString("nome_usuario");
        return View();
    }
}