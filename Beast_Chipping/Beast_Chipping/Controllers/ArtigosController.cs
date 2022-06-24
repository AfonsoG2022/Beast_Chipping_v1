using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beast_Chipping.Data;
using Beast_Chipping.Models;

namespace Beast_Chipping.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtigosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artigos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Artigo.Include(a => a.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Produto)
                .FirstOrDefaultAsync(m => m.numeroSerie == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // GET: Artigos/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.Set<Produto>(), "Id", "Id");
            return View();
        }

        // POST: Artigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numeroSerie,Cor,Vendido,IdProduto")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduto"] = new SelectList(_context.Set<Produto>(), "Id", "Id", artigo.IdProduto);
            return View(artigo);
        }

        // GET: Artigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }
            ViewData["IdProduto"] = new SelectList(_context.Set<Produto>(), "Id", "Id", artigo.IdProduto);
            return View(artigo);
        }

        // POST: Artigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numeroSerie,Cor,Vendido,IdProduto")] Artigo artigo)
        {
            if (id != artigo.numeroSerie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtigoExists(artigo.numeroSerie))
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
            ViewData["IdProduto"] = new SelectList(_context.Set<Produto>(), "Id", "Id", artigo.IdProduto);
            return View(artigo);
        }

        // GET: Artigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Produto)
                .FirstOrDefaultAsync(m => m.numeroSerie == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artigo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Artigo'  is null.");
            }
            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo != null)
            {
                _context.Artigo.Remove(artigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtigoExists(int id)
        {
          return (_context.Artigo?.Any(e => e.numeroSerie == id)).GetValueOrDefault();
        }
    }
}
