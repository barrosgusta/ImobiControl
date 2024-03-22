using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImobiControl.Data;
using ImobiControl.Models;

namespace ImobiControl.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ImobiControlContext _context;

        public CidadeController(ImobiControlContext context)
        {
            _context = context;
        }

        // GET: Cidade
        public async Task<IActionResult> Index()
        {
            var imobiControlContext = _context.Cidade.Include(c => c.Estado);
            return View(await imobiControlContext.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidade/Create
        public IActionResult Create()
        {
            ViewData["EstadoSigla"] = new SelectList(_context.Estado, "Sigla", "Sigla");
            return View();
        }

        // POST: Cidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,EstadoSigla")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Id = Guid.NewGuid();
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoSigla"] = new SelectList(_context.Estado, "Sigla", "Sigla", cidade.EstadoSigla);
            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["EstadoSigla"] = new SelectList(_context.Estado, "Sigla", "Sigla", cidade.EstadoSigla);
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,EstadoSigla")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.Id))
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
            ViewData["EstadoSigla"] = new SelectList(_context.Estado, "Sigla", "Sigla", cidade.EstadoSigla);
            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidade.Remove(cidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(Guid id)
        {
            return _context.Cidade.Any(e => e.Id == id);
        }
    }
}
