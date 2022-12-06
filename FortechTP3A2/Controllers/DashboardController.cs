using FortechTP3A2.Data;
using FortechTP3A2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FortechTP3A2.Controllers;

public class DashboardController : Controller
{
    private readonly FortechContext _context;

    public DashboardController(FortechContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        ViewBag.username = HttpContext.Session.GetString("nome_usuario");
        int idUsuario = (int) HttpContext.Session.GetInt32("id_usuario");

        List<SolicitacaoServico> solicitacaos = _context.SolicitacaoServico.Select(s => s).Where(s => s.UsuarioId == idUsuario).Include(s => s.TiposServico).ThenInclude(t => t.TipoServico).Include(s => s.Eletronicos).ToList();

        return View(solicitacaos);
    }
}