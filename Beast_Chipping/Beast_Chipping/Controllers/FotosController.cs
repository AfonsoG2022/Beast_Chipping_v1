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
    public class FotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fotos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Foto.Include(f => f.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .Include(f => f.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Fotos/Create
        public IActionResult Create()
        {
            ViewData["ProdutoFk"] = new SelectList(_context.Set<Produto>(), "Id", "Id");
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoFk,Ficheiro,Descrição")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoFk"] = new SelectList(_context.Set<Produto>(), "Id", "Id", foto.ProdutoFk);
            return View(foto);
        }

        // GET: Fotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }
            ViewData["ProdutoFk"] = new SelectList(_context.Set<Produto>(), "Id", "Id", foto.ProdutoFk);
            return View(foto);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoFk,Ficheiro,Descrição")] Foto foto)
        {
            if (id != foto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoExists(foto.Id))
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
            ViewData["ProdutoFk"] = new SelectList(_context.Set<Produto>(), "Id", "Id", foto.ProdutoFk);
            return View(foto);
        }

        // GET: Fotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Foto == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .Include(f => f.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Foto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Foto'  is null.");
            }
            var foto = await _context.Foto.FindAsync(id);
            if (foto != null)
            {
                _context.Foto.Remove(foto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(int id)
        {
          return (_context.Foto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
