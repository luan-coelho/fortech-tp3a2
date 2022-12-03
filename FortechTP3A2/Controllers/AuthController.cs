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

        ModelState.AddModelError("Validacao", "Usuário ou senha inválidos.");

        return RedirectToAction("Login", "Auth");
    }
    
    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Cadastrar([Bind("Id,Nome,Email,Senha,Cpf,Rg,DataNascimento,Admin,Ativo")] Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuario);
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

        ModelState.AddModelError("Validacao", "Verifique os campos obrigatórios");

        return RedirectToAction("Cadastro", "Auth");
    }

    private Usuario VerificarCrendenciais(string email, string senha)
    {
        return _context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
    }
}