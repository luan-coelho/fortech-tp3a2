using FortechTP3A2.Data;
using FortechTP3A2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;

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
            HttpContext.Session.SetInt32("id_usuario", usuario.Id);
            HttpContext.Session.SetString("nome_usuario", usuario.Nome);
            return RedirectToAction("Index", "Dashboard");
        }

        ModelState.AddModelError("Message", "Usuário ou senha inválidos");

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

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("id_usuario");
        HttpContext.Session.Remove("nome_usuario");

        return RedirectToAction("Login", "Auth");
    }

    private Usuario VerificarCrendenciais(string email, string senha)
    {
        return _context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}