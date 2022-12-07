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
    public class HistoricoServicoController : Controller
    {
        private readonly FortechContext _context;

        public HistoricoServicoController(FortechContext context)
        {
            _context = context;
        }

        // GET: HistoricoServico
        public async Task<IActionResult> Index()
        {
            var fortechContext = _context.HistoricoServico.Include(h => h.SolicitacaoServico);
            return View(await fortechContext.ToListAsync());
        }

        // GET: HistoricoServico/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.HistoricoServico == null)
            {
                return NotFound();
            }

            var historicoServico = await _context.HistoricoServico
                .Include(h => h.SolicitacaoServico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoServico == null)
            {
                return NotFound();
            }

            return View(historicoServico);
        }

        // GET: HistoricoServico/Create
        public IActionResult Create()
        {
            ViewData["SolicitacaoServicoId"] = new SelectList(_context.SolicitacaoServico, "Id", "Nome");
            return View();
        }

        // POST: HistoricoServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SolicitacaoServicoId,Descricao")] HistoricoServico historicoServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SolicitacaoServicoId"] = new SelectList(_context.SolicitacaoServico, "Id", "Nome", historicoServico.SolicitacaoServicoId);
            return View(historicoServico);
        }

        // GET: HistoricoServico/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HistoricoServico == null)
            {
                return NotFound();
            }

            var historicoServico = await _context.HistoricoServico.FindAsync(id);
            if (historicoServico == null)
            {
                return NotFound();
            }
            ViewData["SolicitacaoServicoId"] = new SelectList(_context.SolicitacaoServico, "Id", "Nome", historicoServico.SolicitacaoServicoId);
            return View(historicoServico);
        }

        // POST: HistoricoServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SolicitacaoServicoId,Descricao")] HistoricoServico historicoServico)
        {
            if (id != historicoServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoServicoExists(historicoServico.Id))
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
            ViewData["SolicitacaoServicoId"] = new SelectList(_context.SolicitacaoServico, "Id", "Nome", historicoServico.SolicitacaoServicoId);
            return View(historicoServico);
        }

        // GET: HistoricoServico/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.HistoricoServico == null)
            {
                return NotFound();
            }

            var historicoServico = await _context.HistoricoServico
                .Include(h => h.SolicitacaoServico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoServico == null)
            {
                return NotFound();
            }

            return View(historicoServico);
        }

        // POST: HistoricoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoricoServico == null)
            {
                return Problem("Entity set 'FortechContext.HistoricoServico'  is null.");
            }
            var historicoServico = await _context.HistoricoServico.FindAsync(id);
            if (historicoServico != null)
            {
                _context.HistoricoServico.Remove(historicoServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoServicoExists(int id)
        {
          return _context.HistoricoServico.Any(e => e.Id == id);
        }
    }
}
