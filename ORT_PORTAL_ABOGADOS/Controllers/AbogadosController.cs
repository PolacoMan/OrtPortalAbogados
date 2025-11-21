using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using ORT_PORTAL_ABOGADOS.Context;
using ORT_PORTAL_ABOGADOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                bool existe = await YaExiste(abogado.Tomo, abogado.Folio, abogado.Dni, abogado.Usuario);
                
                if (!existe)
                {
                    var esValido = await ValidarAbogado(abogado.Tomo, abogado.Folio, abogado.Dni, (int)abogado.Genero, abogado.Nombre, abogado.Apellido);

                    if (esValido)
                    {
                        _context.Add(abogado);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("Usuario", abogado.Usuario);
                        TempData["RegistroOK"] = "Su registro fue exitoso y el login se realizó automáticamente.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["RegisterError"] = "Error al validar abogado, corrobore los datos ingresados.";
                    }
                } else
                {
                    TempData["RegisterError"] = "Error al validar abogado, los datos pertenecen a un profesional ya registrado.";
                }
                
            }
            return View(abogado);
        }

        private async Task<bool> ValidarAbogado(int tomo, int folio, int nroDocumento, int genero, string nombre, string apellido)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:7136/");

            var request = new
            {
                tomo = tomo,
                folio = folio,
                nroDocumento = nroDocumento,
                genero = genero,
                nombre = nombre,
                apellido = apellido
            };

            var response = await client.PostAsJsonAsync("ValidarAbogado", request);

            if (!response.IsSuccessStatusCode)
                return false; 

            bool existe = await response.Content.ReadFromJsonAsync<bool>();
            return existe;
        }

        private async Task<bool> YaExiste(int tomo, int folio, int dni, string usuario)
        {
            bool valueResult = false;

            var abogado = await _context.Abogados
                .FirstOrDefaultAsync(a => a.Tomo == tomo ||
                                          a.Folio == folio ||
                                          a.Dni == dni ||
                                          a.Usuario == usuario);

            if (abogado != null)
            {
                valueResult = true;
            }

            return valueResult;
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
