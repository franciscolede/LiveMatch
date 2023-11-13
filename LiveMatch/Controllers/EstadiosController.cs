using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveMatch.Data;
using LiveMatch.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace LiveMatch.Controllers
{
    public class EstadiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estadios
        public async Task<IActionResult> Index()
        {
              return _context.Estadio != null ? 
                          View(await _context.Estadio.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Estadio'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> ShowData([FromForm] IFormFile ExcelFile)
        {
            try
            {
                Stream stream = ExcelFile.OpenReadStream();

                IWorkbook MyExcel = null;

                if (Path.GetExtension(ExcelFile.FileName) == ".xlsx")
                {
                    MyExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MyExcel = new HSSFWorkbook(stream);
                }

                ISheet ExcelSheet = MyExcel.GetSheetAt(0);

                int rowAmount = ExcelSheet.LastRowNum;

                List<Estadio> estadios = new List<Estadio>();

                for (int i = 0; i <= rowAmount; i++)
                {
                    IRow row = ExcelSheet.GetRow(i);

                    estadios.Add(new Estadio
                    {
                        Nombre = row.GetCell(0).ToString(),
                        Descripcion = row.GetCell(1).ToString(),
                        Capacidad = int.Parse(row.GetCell(2).ToString()),
                        FechaRegistro = ParseFecha(row.GetCell(3).ToString())
                    });
                }

                // Guardar en la base de datos
                foreach (var estadio in estadios)
                {
                    _context.Estadio.Add(estadio);
                }

                await _context.SaveChangesAsync();

                // Redirigir a la acción Index para actualizar la vista
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private DateTime? ParseFecha(string fecha)
        {
            if (DateTime.TryParse(fecha, out DateTime result))
            {
                return result;
            }
            return null;
        }

        // GET: Estadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estadio == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Capacidad,FechaRegistro")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estadio == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Capacidad,FechaRegistro")] Estadio estadio)
        {
            if (id != estadio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.Id))
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
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estadio == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estadio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estadio'  is null.");
            }
            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio != null)
            {
                _context.Estadio.Remove(estadio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadioExists(int id)
        {
          return (_context.Estadio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
