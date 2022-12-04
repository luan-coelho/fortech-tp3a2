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
    public class EletronicoController : Controller
    {
        private readonly FortechContext _context;

        public EletronicoController(FortechContext context)
        {
            _context = context;
        }

        // GET: Eletronico
        public async Task<IActionResult> Index()
        {
            var fortechContext = _context.Eletronico.Include(e => e.Modelo);
            return View(await fortechContext.ToListAsync());
        }

        // GET: Eletronico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eletronico == null)
            {
                return NotFound();
            }

            var eletronico = await _context.Eletronico
                .Include(e => e.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eletronico == null)
            {
                return NotFound();
            }

            return View(eletronico);
        }

        // GET: Eletronico/Create
        public IActionResult Create()
        {
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Descricao");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NumeroNotaFiscal,DataFabricao,Observacoes,ModeloId")] Eletronico eletronicoRequest)
        {
            Modelo modelo = _context.Modelo.FirstOrDefault(m => m.Id == eletronicoRequest.ModeloId);
            
            if (modelo != null)
            {
                eletronicoRequest.Modelo = modelo;
                _context.Add(eletronicoRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Descricao", eletronicoRequest.ModeloId);
            return View(eletronicoRequest);
        }

        // GET: Eletronico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eletronico == null)
            {
                return NotFound();
            }

            var eletronico = await _context.Eletronico.FindAsync(id);
            if (eletronico == null)
            {
                return NotFound();
            }
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Descricao", eletronico.ModeloId);
            return View(eletronico);
        }

        // POST: Eletronico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NumeroNotaFiscal,DataFabricao,Observacoes,ModeloId")] Eletronico eletronico)
        {
            if (id != eletronico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eletronico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EletronicoExists(eletronico.Id))
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
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "Id", "Descricao", eletronico.ModeloId);
            return View(eletronico);
        }

        // GET: Eletronico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eletronico == null)
            {
                return NotFound();
            }

            var eletronico = await _context.Eletronico
                .Include(e => e.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eletronico == null)
            {
                return NotFound();
            }

            return View(eletronico);
        }

        // POST: Eletronico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eletronico == null)
            {
                return Problem("Entity set 'FortechContext.Eletronico'  is null.");
            }
            var eletronico = await _context.Eletronico.FindAsync(id);
            if (eletronico != null)
            {
                _context.Eletronico.Remove(eletronico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EletronicoExists(int id)
        {
          return _context.Eletronico.Any(e => e.Id == id);
        }
    }
}
