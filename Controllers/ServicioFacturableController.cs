using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCajaUnapec.Data;
using SistemaCajaUnapec.Models;

namespace SistemaCajaUnapec.Controllers
{
    public class ServicioFacturableController : Controller
    {
        private readonly CajaContext _context;

        public ServicioFacturableController(CajaContext context)
        {
            _context = context;
        }

        // GET: ServicioFacturable
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiciosFacturables.ToListAsync());
        }

        // GET: ServicioFacturable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioFacturable = await _context.ServiciosFacturables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioFacturable == null)
            {
                return NotFound();
            }

            return View(servicioFacturable);
        }

        // GET: ServicioFacturable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioFacturable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio")] ServicioFacturable servicioFacturable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioFacturable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioFacturable);
        }

        // GET: ServicioFacturable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioFacturable = await _context.ServiciosFacturables.FindAsync(id);
            if (servicioFacturable == null)
            {
                return NotFound();
            }
            return View(servicioFacturable);
        }

        // POST: ServicioFacturable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio")] ServicioFacturable servicioFacturable)
        {
            if (id != servicioFacturable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioFacturable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioFacturableExists(servicioFacturable.Id))
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
            return View(servicioFacturable);
        }

        // GET: ServicioFacturable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioFacturable = await _context.ServiciosFacturables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioFacturable == null)
            {
                return NotFound();
            }

            return View(servicioFacturable);
        }

        // POST: ServicioFacturable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioFacturable = await _context.ServiciosFacturables.FindAsync(id);
            if (servicioFacturable != null)
            {
                _context.ServiciosFacturables.Remove(servicioFacturable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioFacturableExists(int id)
        {
            return _context.ServiciosFacturables.Any(e => e.Id == id);
        }
    }
}
