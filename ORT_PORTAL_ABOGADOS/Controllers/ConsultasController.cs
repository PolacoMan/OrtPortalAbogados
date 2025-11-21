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
    public class ConsultasController : Controller
    {
        private readonly DBContext _context;
        private readonly AccesoController _acceso;


        public ConsultasController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ConsultasActivas()
        {
            var usuario = HttpContext.Session.GetString("Usuario");

            if (usuario == null)
                return RedirectToAction("Login", "Acceso");

            var abogado = await _context.Abogados
                .FirstOrDefaultAsync(a => a.Usuario == usuario);

            int idUsuario = abogado?.Id ?? -1;

            ViewBag.IdUsuario = idUsuario;

            var consultasActivasList = await _context.Consultas.ToListAsync();

            return View(consultasActivasList);
        }

        public async Task<IActionResult> SolicitudesPendientes()
        {
            //método del controller para mostrar las solicitudes pendientes
            var solicitudesList = await _context.Consultas.Where(c => c.EstaActiva == false && c.IdAbogado == 0).ToListAsync();
            return View(solicitudesList);
        }
        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultas.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Crear()
        {
            return View();
        }
        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,NombreCliente,ApellidoCliente,MailCliente")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                consulta.Precio = 0;
                consulta.EstaActiva = false;
                _context.Add(consulta);
                await _context.SaveChangesAsync();

                TempData["CrearExitoso"] = "true";

                return RedirectToAction(nameof(Crear));
            }
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Precio,NombreCliente,ApellidoCliente,MailCliente,EstaActiva")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> FinalizarConsulta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("FinalizarConsulta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizConf(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ConsultasActivas));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AceptarSolicitud(int id, double precio)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
                return NotFound();
            var usuario = HttpContext.Session.GetString("Usuario");
            var abogado = await _context.Abogados.FirstOrDefaultAsync(a => a.Usuario == usuario);
            consulta.IdAbogado = abogado.Id;
            consulta.SetPrecio(precio);
            consulta.CambiarEstado();
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(SolicitudesPendientes));
        }
    }
}
