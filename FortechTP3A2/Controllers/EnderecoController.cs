using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FortechTP3A2.Data;
using FortechTP3A2.Models;

namespace FortechTP3A2.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly FortechContext _context;

        public EnderecoController(FortechContext context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var fortechContext = _context.Endereco.Include(e => e.Usuario).Where(e => e.UsuarioId == id);
            return View(await fortechContext.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("id,cep,rua,numero,bairro,complemento,cidade,estado,UsuarioId")]
            Endereco endereco)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Id == endereco.UsuarioId);

            if (usuario != null)
            {
                endereco.Usuario = usuario;
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return Redirect("/Endereco/Index/" + endereco.UsuarioId);
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", endereco.UsuarioId);
            return View(endereco);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", endereco.UsuarioId);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("id,cep,rua,numero,bairro,complemento,cidade,estado,UsuarioId")]
            Endereco endereco)
        {
            if (id != endereco.id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(endereco);
                await _context.SaveChangesAsync();
                return Redirect("/Endereco/Index/" + endereco.UsuarioId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.id))
                {
                    return NotFound();
                }
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", endereco.UsuarioId);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endereco == null)
            {
                return Problem("Entity set 'FortechContext.Endereco'  is null.");
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.id == id);
        }
    }
}