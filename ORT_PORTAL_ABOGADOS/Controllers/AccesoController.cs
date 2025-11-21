using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORT_PORTAL_ABOGADOS.Context;
using ORT_PORTAL_ABOGADOS.Models;

namespace ORT_PORTAL_ABOGADOS.Controllers
{
    public class AccesoController : Controller
    {

        private readonly DBContext _context;

        public AccesoController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            var abogado = BuscarUsuario(usuario).Result;
            if (abogado != null && password == abogado.Password)
            {
                HttpContext.Session.SetString("Usuario", usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }
                TempData["LoginError"] = "Credenciales incorrectas";
            return RedirectToAction("Index", "Home");
        }

        public async Task<Abogado> BuscarUsuario(string user)
        {
            var abogado = await _context.Abogados.FirstOrDefaultAsync(a => a.Usuario == user);
            return abogado;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public async Task<int> GetAbogadoId(string usuario)
        {
            var abogado = await BuscarUsuario(usuario);
            return abogado.Id;
        }
    }

}
