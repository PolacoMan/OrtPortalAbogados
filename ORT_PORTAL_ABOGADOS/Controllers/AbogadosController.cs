using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORT_PORTAL_ABOGADOS.Context;
using ORT_PORTAL_ABOGADOS.Models;

namespace ORT_PORTAL_ABOGADOS.Controllers
{
    public class AbogadosController : Controller
    {
        private readonly DBContext _context;

        public AbogadosController(DBContext context)
        {
            _context = context;
        }

        // GET: Abogados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Abogados.ToListAsync());
        }

        // GET: Abogados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogado = await _context.Abogados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }

            return View(abogado);
        }

        // GET: Abogados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abogados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Tomo,Folio,Genero,Dni,Area,Usuario,Password")] Abogado abogado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abogado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abogado);
        }

        // GET: Abogados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogado = await _context.Abogados.FindAsync(id);
            if (abogado == null)
            {
                return NotFound();
            }
            return View(abogado);
        }

        // POST: Abogados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Tomo,Folio,Genero,Dni,Area,Usuario,Password")] Abogado abogado)
        {
            if (id != abogado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abogado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbogadoExists(abogado.Id))
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
            return View(abogado);
        }

        // GET: Abogados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogado = await _context.Abogados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }

            return View(abogado);
        }

        // POST: Abogados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abogado = await _context.Abogados.FindAsync(id);
            if (abogado != null)
            {
                _context.Abogados.Remove(abogado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbogadoExists(int id)
        {
            return _context.Abogados.Any(e => e.Id == id);
        }
    }
}
