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
    public class TipoEspectadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoEspectadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoEspectadores
        public async Task<IActionResult> Index()
        {
              return _context.TipoEspectadores != null ? 
                          View(await _context.TipoEspectadores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TipoEspectadores'  is null.");
        }

        // GET: TipoEspectadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEspectadores == null)
            {
                return NotFound();
            }

            var tipoEspectador = await _context.TipoEspectadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEspectador == null)
            {
                return NotFound();
            }

            return View(tipoEspectador);
        }

        // GET: TipoEspectadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEspectadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaRegistro")] TipoEspectador tipoEspectador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEspectador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEspectador);
        }

        // GET: TipoEspectadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEspectadores == null)
            {
                return NotFound();
            }

            var tipoEspectador = await _context.TipoEspectadores.FindAsync(id);
            if (tipoEspectador == null)
            {
                return NotFound();
            }
            return View(tipoEspectador);
        }

        // POST: TipoEspectadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaRegistro")] TipoEspectador tipoEspectador)
        {
            if (id != tipoEspectador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEspectador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEspectadorExists(tipoEspectador.Id))
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
            return View(tipoEspectador);
        }

        // GET: TipoEspectadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEspectadores == null)
            {
                return NotFound();
            }

            var tipoEspectador = await _context.TipoEspectadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEspectador == null)
            {
                return NotFound();
            }

            return View(tipoEspectador);
        }

        // POST: TipoEspectadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEspectadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoEspectadores'  is null.");
            }
            var tipoEspectador = await _context.TipoEspectadores.FindAsync(id);
            if (tipoEspectador != null)
            {
                _context.TipoEspectadores.Remove(tipoEspectador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEspectadorExists(int id)
        {
          return (_context.TipoEspectadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
