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
    public class UbicacionesEstadioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UbicacionesEstadioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UbicacionesEstadio
        public async Task<IActionResult> Index()
        {
              return _context.UbicacionesEstadio != null ? 
                          View(await _context.UbicacionesEstadio.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UbicacionesEstadio'  is null.");
        }

        // GET: UbicacionesEstadio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UbicacionesEstadio == null)
            {
                return NotFound();
            }

            var ubicacionEstadio = await _context.UbicacionesEstadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacionEstadio == null)
            {
                return NotFound();
            }

            return View(ubicacionEstadio);
        }

        // GET: UbicacionesEstadio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UbicacionesEstadio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaRegistro")] UbicacionEstadio ubicacionEstadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacionEstadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacionEstadio);
        }

        // GET: UbicacionesEstadio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UbicacionesEstadio == null)
            {
                return NotFound();
            }

            var ubicacionEstadio = await _context.UbicacionesEstadio.FindAsync(id);
            if (ubicacionEstadio == null)
            {
                return NotFound();
            }
            return View(ubicacionEstadio);
        }

        // POST: UbicacionesEstadio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaRegistro")] UbicacionEstadio ubicacionEstadio)
        {
            if (id != ubicacionEstadio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacionEstadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionEstadioExists(ubicacionEstadio.Id))
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
            return View(ubicacionEstadio);
        }

        // GET: UbicacionesEstadio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UbicacionesEstadio == null)
            {
                return NotFound();
            }

            var ubicacionEstadio = await _context.UbicacionesEstadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ubicacionEstadio == null)
            {
                return NotFound();
            }

            return View(ubicacionEstadio);
        }

        // POST: UbicacionesEstadio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UbicacionesEstadio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UbicacionesEstadio'  is null.");
            }
            var ubicacionEstadio = await _context.UbicacionesEstadio.FindAsync(id);
            if (ubicacionEstadio != null)
            {
                _context.UbicacionesEstadio.Remove(ubicacionEstadio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionEstadioExists(int id)
        {
          return (_context.UbicacionesEstadio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
