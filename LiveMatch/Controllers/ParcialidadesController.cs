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
    public class ParcialidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParcialidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parcialidades
        public async Task<IActionResult> Index()
        {
              return _context.Parcialidades != null ? 
                          View(await _context.Parcialidades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Parcialidades'  is null.");
        }

        // GET: Parcialidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parcialidades == null)
            {
                return NotFound();
            }

            var parcialidad = await _context.Parcialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcialidad == null)
            {
                return NotFound();
            }

            return View(parcialidad);
        }

        // GET: Parcialidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parcialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaRegistro")] Parcialidad parcialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parcialidad);
        }

        // GET: Parcialidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parcialidades == null)
            {
                return NotFound();
            }

            var parcialidad = await _context.Parcialidades.FindAsync(id);
            if (parcialidad == null)
            {
                return NotFound();
            }
            return View(parcialidad);
        }

        // POST: Parcialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaRegistro")] Parcialidad parcialidad)
        {
            if (id != parcialidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcialidadExists(parcialidad.Id))
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
            return View(parcialidad);
        }

        // GET: Parcialidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parcialidades == null)
            {
                return NotFound();
            }

            var parcialidad = await _context.Parcialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcialidad == null)
            {
                return NotFound();
            }

            return View(parcialidad);
        }

        // POST: Parcialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parcialidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Parcialidades'  is null.");
            }
            var parcialidad = await _context.Parcialidades.FindAsync(id);
            if (parcialidad != null)
            {
                _context.Parcialidades.Remove(parcialidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcialidadExists(int id)
        {
          return (_context.Parcialidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
