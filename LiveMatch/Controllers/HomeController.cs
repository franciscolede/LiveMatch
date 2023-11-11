using LiveMatch.Data;
using LiveMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LiveMatch.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public HomeController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Eventos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            if(ModelState.IsValid)
            {
                _contexto.Eventos.Add(evento);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = _contexto.Eventos.Find(id);
            if(evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(evento);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = _contexto.Eventos.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = _contexto.Eventos.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEvento(int? id)
        {
            var evento = await _contexto.Eventos.FindAsync(id);
            if (evento == null)
            {
                return View();
            }

            _contexto.Eventos.Remove(evento);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}