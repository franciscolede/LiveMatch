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
    public class EntradasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntradasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entradas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entradas.Include(e => e.Evento).Include(e => e.Parcialidad).Include(e => e.TipoEspectador).Include(e => e.UbicacionEstadio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.Evento)
                .Include(e => e.Parcialidad)
                .Include(e => e.TipoEspectador)
                .Include(e => e.UbicacionEstadio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entradas/Create
        public IActionResult Create()
        {
            ViewData["EventoRefId"] = new SelectList(_context.Eventos, "Id", "NombreCompleto");
            ViewData["ParcialidadRefId"] = new SelectList(_context.Parcialidades, "Id", "Nombre");
            ViewData["TipoEspectadorRefId"] = new SelectList(_context.TipoEspectadores, "Id", "Nombre");
            ViewData["UbicacionEstadioRefId"] = new SelectList(_context.UbicacionesEstadio, "Id", "Nombre");
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoRefId,ParcialidadRefId,TipoEspectadorRefId,UbicacionEstadioRefId,Descripcion,Precio")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoRefId"] = new SelectList(_context.Eventos, "Id", "Local", entrada.EventoRefId);
            ViewData["ParcialidadRefId"] = new SelectList(_context.Parcialidades, "Id", "Id", entrada.ParcialidadRefId);
            ViewData["TipoEspectadorRefId"] = new SelectList(_context.TipoEspectadores, "Id", "Id", entrada.TipoEspectadorRefId);
            ViewData["UbicacionEstadioRefId"] = new SelectList(_context.UbicacionesEstadio, "Id", "Id", entrada.UbicacionEstadioRefId);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["EventoRefId"] = new SelectList(_context.Eventos, "Id", "NombreCompleto", entrada.EventoRefId);
            ViewData["ParcialidadRefId"] = new SelectList(_context.Parcialidades, "Id", "Nombre", entrada.ParcialidadRefId);
            ViewData["TipoEspectadorRefId"] = new SelectList(_context.TipoEspectadores, "Id", "Nombre", entrada.TipoEspectadorRefId);
            ViewData["UbicacionEstadioRefId"] = new SelectList(_context.UbicacionesEstadio, "Id", "Nombre", entrada.UbicacionEstadioRefId);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoRefId,ParcialidadRefId,TipoEspectadorRefId,UbicacionEstadioRefId,Descripcion,Precio")] Entrada entrada)
        {
            if (id != entrada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.Id))
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
            ViewData["EventoRefId"] = new SelectList(_context.Eventos, "Id", "Local", entrada.EventoRefId);
            ViewData["ParcialidadRefId"] = new SelectList(_context.Parcialidades, "Id", "Id", entrada.ParcialidadRefId);
            ViewData["TipoEspectadorRefId"] = new SelectList(_context.TipoEspectadores, "Id", "Id", entrada.TipoEspectadorRefId);
            ViewData["UbicacionEstadioRefId"] = new SelectList(_context.UbicacionesEstadio, "Id", "Id", entrada.UbicacionEstadioRefId);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.Evento)
                .Include(e => e.Parcialidad)
                .Include(e => e.TipoEspectador)
                .Include(e => e.UbicacionEstadio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entradas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Entradas'  is null.");
            }
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
          return (_context.Entradas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
