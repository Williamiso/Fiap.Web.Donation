using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.Donation.Data;
using Fiap.Web.Donation.Models;

namespace Fiap.Web.Donation.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly DataContext _context;

        public TipoProdutoController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoProduto
        public async Task<IActionResult> Index()
        {
              return _context.TipoProdutos != null ? 
                          View(await _context.TipoProdutos.ToListAsync()) :
                          Problem("Entity set 'DataContext.TipoProdutos'  is null.");
        }

        // GET: TipoProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoProdutos == null)
            {
                return NotFound();
            }

            var tipoProdutoModel = await _context.TipoProdutos
                .FirstOrDefaultAsync(m => m.TipoProdutoId == id);
            if (tipoProdutoModel == null)
            {
                return NotFound();
            }

            return View(tipoProdutoModel);
        }

        // GET: TipoProduto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id,Descricao")] TipoProdutoModel tipoProdutoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProdutoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProdutoModel);
        }

        // GET: TipoProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoProdutos == null)
            {
                return NotFound();
            }

            var tipoProdutoModel = await _context.TipoProdutos.FindAsync(id);
            if (tipoProdutoModel == null)
            {
                return NotFound();
            }
            return View(tipoProdutoModel);
        }

        // POST: TipoProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id,Descricao")] TipoProdutoModel tipoProdutoModel)
        {
            if (id != tipoProdutoModel.TipoProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProdutoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoModelExists(tipoProdutoModel.TipoProdutoId))
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
            return View(tipoProdutoModel);
        }

        // GET: TipoProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoProdutos == null)
            {
                return NotFound();
            }

            var tipoProdutoModel = await _context.TipoProdutos
                .FirstOrDefaultAsync(m => m.TipoProdutoId == id);
            if (tipoProdutoModel == null)
            {
                return NotFound();
            }

            return View(tipoProdutoModel);
        }

        // POST: TipoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoProdutos == null)
            {
                return Problem("Entity set 'DataContext.TipoProdutos'  is null.");
            }
            var tipoProdutoModel = await _context.TipoProdutos.FindAsync(id);
            if (tipoProdutoModel != null)
            {
                _context.TipoProdutos.Remove(tipoProdutoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdutoModelExists(int id)
        {
          return (_context.TipoProdutos?.Any(e => e.TipoProdutoId == id)).GetValueOrDefault();
        }
    }
}
