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
    public class ImovelController : Controller
    {
        private readonly ImobiControlContext _context;

        public ImovelController(ImobiControlContext context)
        {
            _context = context;
        }

        // GET: Imovel
        public async Task<IActionResult> Index()
        {
            var imobiControlContext = _context.Imovel.Include(i => i.Cidade).Include(i => i.Pessoa).Include(i => i.Tipo);
            return View(await imobiControlContext.ToListAsync());
        }

        // GET: Imovel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Cidade)
                .Include(i => i.Pessoa)
                .Include(i => i.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovel/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "EstadoSigla");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Bairro");
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Descricao");
            return View();
        }

        // POST: Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco,Numero,Bairro,Complemento,Cep,Preco,Avaliacao,Finalidade,AreaTotal,AreaConstruida,Comodos,VagaGaragem,TaxaComissao,CidadeId,TipoId,PessoaId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                imovel.Id = Guid.NewGuid();
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "EstadoSigla", imovel.CidadeId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Bairro", imovel.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Descricao", imovel.TipoId);
            return View(imovel);
        }

        // GET: Imovel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "EstadoSigla", imovel.CidadeId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Bairro", imovel.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Descricao", imovel.TipoId);
            return View(imovel);
        }

        // POST: Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Endereco,Numero,Bairro,Complemento,Cep,Preco,Avaliacao,Finalidade,AreaTotal,AreaConstruida,Comodos,VagaGaragem,TaxaComissao,CidadeId,TipoId,PessoaId")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "EstadoSigla", imovel.CidadeId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Bairro", imovel.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Descricao", imovel.TipoId);
            return View(imovel);
        }

        // GET: Imovel/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Cidade)
                .Include(i => i.Pessoa)
                .Include(i => i.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel != null)
            {
                _context.Imovel.Remove(imovel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(Guid id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
