using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LiveMatch.Data;
using LiveMatch.Models;

namespace LiveMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var eventos = await _context.Eventos.ToListAsync();

            var viewModelList = new List<EventoEntradasViewModel>();

            foreach (var evento in eventos)
            {
                // Consulta para cargar las entradas y sus propiedades relacionadas
                var entradas = await _context.Entradas
                    .Include(e => e.Parcialidad)
                    .Include(e => e.TipoEspectador)
                    .Include(e => e.UbicacionEstadio)
                    .Where(e => e.EventoRefId == evento.Id)
                    .ToListAsync();

                var viewModel = new EventoEntradasViewModel
                {
                    Evento = evento,
                    Entradas = entradas // Ajusta según tus necesidades
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}