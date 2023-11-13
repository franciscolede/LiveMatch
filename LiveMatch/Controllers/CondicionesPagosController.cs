using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveMatch.Data;
using LiveMatch.Models;

namespace LiveMatch.Controllers
{
    public class CondicionesPagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CondicionesPagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CondicionesPagos
        public async Task<IActionResult> Index()
        {
              return _context.CondicionPagos != null ? 
                          View(await _context.CondicionPagos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CondicionPagos'  is null.");
        }

        // GET: CondicionesPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CondicionPagos == null)
            {
                return NotFound();
            }

            var condicionPago = await _context.CondicionPagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condicionPago == null)
            {
                return NotFound();
            }

            return View(condicionPago);
        }

        // GET: CondicionesPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CondicionesPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,FechaRegistro")] CondicionPago condicionPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicionPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicionPago);
        }

        // GET: CondicionesPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CondicionPagos == null)
            {
                return NotFound();
            }

            var condicionPago = await _context.CondicionPagos.FindAsync(id);
            if (condicionPago == null)
            {
                return NotFound();
            }
            return View(condicionPago);
        }

        // POST: CondicionesPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FechaRegistro")] CondicionPago condicionPago)
        {
            if (id != condicionPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicionPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionPagoExists(condicionPago.Id))
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
            return View(condicionPago);
        }

        // GET: CondicionesPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CondicionPagos == null)
            {
                return NotFound();
            }

            var condicionPago = await _context.CondicionPagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condicionPago == null)
            {
                return NotFound();
            }

            return View(condicionPago);
        }

        // POST: CondicionesPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CondicionPagos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CondicionPagos'  is null.");
            }
            var condicionPago = await _context.CondicionPagos.FindAsync(id);
            if (condicionPago != null)
            {
                _context.CondicionPagos.Remove(condicionPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionPagoExists(int id)
        {
          return (_context.CondicionPagos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
