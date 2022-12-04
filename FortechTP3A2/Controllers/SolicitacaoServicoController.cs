using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FortechTP3A2.Data;
using FortechTP3A2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace FortechTP3A2.Controllers
{
    public class SolicitacaoServicoController : Controller
    {
        private readonly FortechContext _context;

        public SolicitacaoServicoController(FortechContext context)
        {
            _context = context;
        }

        // GET: SolicitacaoServico
        public async Task<IActionResult> Index()
        {
            var fortechContext = _context.SolicitacaoServico.Include(s => s.Usuario);
            return View(await fortechContext.ToListAsync());
        }

        // GET: SolicitacaoServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SolicitacaoServico == null)
            {
                return NotFound();
            }

            var solicitacaoServico = await _context.SolicitacaoServico
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacaoServico == null)
            {
                return NotFound();
            }

            return View(solicitacaoServico);
        }

        // GET: SolicitacaoServico/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome");
            ViewData["Eletronicos"] = new SelectList(_context.Eletronico, "Id", "Nome");
            ViewData["TiposServico"] = new SelectList(_context.TipoServico, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Nome,Detalhes,Valor,UsuarioId,TiposServico")]
            SolicitacaoServico solicitacaoServicoRequest)
        {
            StringValues listaIdTipoServico = Request.Form["TiposServico"];

            foreach (var tipoServicoId in listaIdTipoServico)
            {
                int id = int.Parse(tipoServicoId);
                TipoServico tipoServico = _context.TipoServico.FirstOrDefault(t => t.Id == id);
                solicitacaoServicoRequest.TiposServico = new List<SolicitacaoTipoServico>();
                SolicitacaoTipoServico solicitacaoTipoServico = new SolicitacaoTipoServico();
                solicitacaoTipoServico.TipoServico = tipoServico;
                solicitacaoTipoServico.SolicitacaoServico = solicitacaoServicoRequest;
                solicitacaoServicoRequest.TiposServico.Add(solicitacaoTipoServico);
            }

            if (ModelState.IsValid)
            {
                _context.Add(solicitacaoServicoRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Cpf", solicitacaoServicoRequest.UsuarioId);
            return View(solicitacaoServicoRequest);
        }

        // GET: SolicitacaoServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SolicitacaoServico == null)
            {
                return NotFound();
            }

            var solicitacaoServico = await _context.SolicitacaoServico.FindAsync(id);
            if (solicitacaoServico == null)
            {
                return NotFound();
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Cpf", solicitacaoServico.UsuarioId);
            return View(solicitacaoServico);
        }

        // POST: SolicitacaoServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Nome,Detalhes,Valor,UsuarioId")]
            SolicitacaoServico solicitacaoServico)
        {
            if (id != solicitacaoServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitacaoServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitacaoServicoExists(solicitacaoServico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Cpf", solicitacaoServico.UsuarioId);
            return View(solicitacaoServico);
        }

        // GET: SolicitacaoServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SolicitacaoServico == null)
            {
                return NotFound();
            }

            var solicitacaoServico = await _context.SolicitacaoServico
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacaoServico == null)
            {
                return NotFound();
            }

            return View(solicitacaoServico);
        }

        // POST: SolicitacaoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SolicitacaoServico == null)
            {
                return Problem("Entity set 'FortechContext.SolicitacaoServico'  is null.");
            }

            var solicitacaoServico = await _context.SolicitacaoServico.FindAsync(id);
            if (solicitacaoServico != null)
            {
                _context.SolicitacaoServico.Remove(solicitacaoServico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitacaoServicoExists(int id)
        {
            return _context.SolicitacaoServico.Any(e => e.Id == id);
        }
    }
}