using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCajaUnapec.Data;
using SistemaCajaUnapec.Models;

namespace SistemaCajaUnapec.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly CajaContext _context;

        public TipoDocumentoController(CajaContext context)
        {
            _context = context;
        }

        // GET: TipoDocumento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDocumentos.ToListAsync());
        }

        // GET: TipoDocumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tipoDocumento = await _context.TiposDocumentos.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null) return NotFound();

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Estado")] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error}"); // Esto mostrará los errores en la consola
                }
                return View(tipoDocumento);
            }

            _context.Add(tipoDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: TipoDocumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tipoDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tipoDocumento == null) return NotFound();

            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificador,Descripcion,Estado")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tipoDocumento = await _context.TiposDocumentos.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null) return NotFound();

            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tipoDocumento != null)
            {
                _context.TiposDocumentos.Remove(tipoDocumento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.TiposDocumentos.Any(e => e.Id == id);
        }
    }
}
