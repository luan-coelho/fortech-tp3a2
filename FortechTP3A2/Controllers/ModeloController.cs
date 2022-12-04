using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FortechTP3A2.Data;
using FortechTP3A2.Models;
using Microsoft.Win32;

namespace FortechTP3A2.Controllers
{
    public class ModeloController : Controller
    {
        private readonly FortechContext _context;

        public ModeloController(FortechContext context)
        {
            _context = context;
        }

        // GET: Modelo
        public async Task<IActionResult> Index()
        {
            var fortechContext = _context.Modelo.Include(m => m.Marca);
            return View(await fortechContext.ToListAsync());
        }

        // GET: Modelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modelo/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,MarcaId")] Modelo modelo)
        {
            Marca marca = _context.Marca.FirstOrDefault(m => m.Id == modelo.MarcaId);

            modelo.Marca = marca;

            if (modelo.Marca != null)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", modelo.MarcaId);
            return View(modelo);
        }

        // GET: Modelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", modelo.MarcaId);
            return View(modelo);
        }

        // POST: Modelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,MarcaId")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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

            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", modelo.MarcaId);
            return View(modelo);
        }

        // GET: Modelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modelo == null)
            {
                return Problem("Entity set 'FortechContext.Modelo'  is null.");
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo != null)
            {
                _context.Modelo.Remove(modelo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.Id == id);
        }
    }
}