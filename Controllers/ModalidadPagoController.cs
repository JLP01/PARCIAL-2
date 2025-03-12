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
    public class ModalidadPagoController : Controller
    {
        private readonly CajaContext _context;

        public ModalidadPagoController(CajaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ModalidadesPago.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadPago = await _context.ModalidadesPago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidadPago == null)
            {
                return NotFound();
            }

            return View(modalidadPago);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NumeroCuotas,Descripcion,Estado")] ModalidadPago modalidadPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidadPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidadPago);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadPago = await _context.ModalidadesPago.FindAsync(id);
            if (modalidadPago == null)
            {
                return NotFound();
            }
            return View(modalidadPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NumeroCuotas,Descripcion,Estado")] ModalidadPago modalidadPago)
        {
            if (id != modalidadPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidadPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadPagoExists(modalidadPago.Id))
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
            return View(modalidadPago);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadPago = await _context.ModalidadesPago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidadPago == null)
            {
                return NotFound();
            }

            return View(modalidadPago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidadPago = await _context.ModalidadesPago.FindAsync(id);
            if (modalidadPago != null)
            {
                _context.ModalidadesPago.Remove(modalidadPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadPagoExists(int id)
        {
            return _context.ModalidadesPago.Any(e => e.Id == id);
        }
    }
}
