using FortechTP3A2.Data;
using FortechTP3A2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FortechTP3A2.Controllers;

public class AuthController : Controller
{
    private readonly FortechContext _context;

    public AuthController(FortechContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult VerificarLogin(string email, string senha)
    {
        Usuario usuario = VerificarCrendenciais(email, senha);

        if (usuario != null)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        ViewData["Message"] = "Usuário ou senha inválidos";

        return RedirectToAction("Login", "Auth");
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastro(
        [Bind("Id,Nome,Email,Senha,Cpf,Rg,DataNascimento,Admin,Ativo")]
        Usuario usuario)
    {
        usuario.Ativo = true;

        if (!ModelState.IsValid) return View(usuario);

        _context.Add(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Login));
    }

    private Usuario VerificarCrendenciais(string email, string senha)
    {
        return _context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
    }
}