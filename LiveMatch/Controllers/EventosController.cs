using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveMatch.Data;
using LiveMatch.Models;
using Microsoft.AspNetCore.Hosting;

namespace LiveMatch.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public EventosController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eventos
                .Include(e => e.Estadio)
                .Include(e => e.Deporte);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Estadio)
                .Include(e => e.Deporte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["EstadioRefId"] = new SelectList(_context.Estadio, "Id", "Nombre");
            ViewData["DeporteRefId"] = new SelectList(_context.Deporte, "Id", "Nombre");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local,Visitante,ImagenEvento,DeporteRefId,EstadioRefId,FechaEvento")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var imageFile = files[0];
                    var pathDestination = Path.Combine(env.WebRootPath, "images\\eventos");
                    if (imageFile.Length > 0)
                    {
                        //generar nombre aleatorio
                        var fileDestination = Guid.NewGuid().ToString();
                        fileDestination = fileDestination.Replace("-", "");
                        fileDestination += Path.GetExtension(imageFile.FileName);
                        var DestinationRoute = Path.Combine(pathDestination, fileDestination);
                        using (var filestream = new FileStream(DestinationRoute, FileMode.Create))
                        {
                            imageFile.CopyTo(filestream);
                            evento.ImagenEvento = fileDestination;
                        }
                    }
                }


                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadioRefId"] = new SelectList(_context.Estadio, "Id", "Nombre", evento.EstadioRefId);
            ViewData["DeporteRefId"] = new SelectList(_context.Deporte, "Id", "Nombre", evento.DeporteRefId);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["EstadioRefId"] = new SelectList(_context.Estadio, "Id", "Nombre", evento.EstadioRefId);
            ViewData["DeporteRefId"] = new SelectList(_context.Deporte, "Id", "Nombre", evento.DeporteRefId);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local,Visitante,ImagenEvento,DeporteRefId,EstadioRefId,FechaEvento")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var imageFile = files[0];
                    var pathDestination = Path.Combine(env.WebRootPath, "images\\eventos");
                    if (imageFile.Length > 0)
                    {
                        //generar nombre aleatorio
                        var fileDestination = Guid.NewGuid().ToString();
                        fileDestination = fileDestination.Replace("-", "");
                        fileDestination += Path.GetExtension(imageFile.FileName);
                        var DestinationRoute = Path.Combine(pathDestination, fileDestination);


                        if (!string.IsNullOrEmpty(evento.ImagenEvento))
                        {
                            string lastImage = Path.Combine(pathDestination, evento.ImagenEvento);
                            if (System.IO.File.Exists(lastImage))
                                System.IO.File.Delete(lastImage);
                        }
                        


                        using (var filestream = new FileStream(DestinationRoute, FileMode.Create))
                        {
                            imageFile.CopyTo(filestream);
                            evento.ImagenEvento = fileDestination;
                        }
                    }
                }

                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewData["EstadioRefId"] = new SelectList(_context.Estadio, "Id", "Nombre", evento.EstadioRefId);
            ViewData["DeporteRefId"] = new SelectList(_context.Deporte, "Id", "Nombre", evento.DeporteRefId);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Estadio)
                .Include(e => e.Deporte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eventos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Eventos'  is null.");
            }
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
          return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
