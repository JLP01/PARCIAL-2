using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCajaUnapec.Data;

namespace SistemaCajaUnapec.Controllers
{
    public class FormaPagoController : Controller
    {
        private readonly CajaContext _context;

        public FormaPagoController(CajaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FormasPago.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var formaPago = await _context.FormasPago.FirstOrDefaultAsync(m => m.Id == id);
            if (formaPago == null) return NotFound();

            return View(formaPago);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Estado")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPago);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var formaPago = await _context.FormasPago.FindAsync(id);
            if (formaPago == null) return NotFound();

            return View(formaPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Estado")] FormaPago formaPago)
        {
            if (id != formaPago.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagoExists(formaPago.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(formaPago);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var formaPago = await _context.FormasPago.FirstOrDefaultAsync(m => m.Id == id);
            if (formaPago == null) return NotFound();

            return View(formaPago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPago = await _context.FormasPago.FindAsync(id);
            if (formaPago != null) _context.FormasPago.Remove(formaPago);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagoExists(int id)
        {
            return _context.FormasPago.Any(e => e.Id == id);
        }
    }
}

