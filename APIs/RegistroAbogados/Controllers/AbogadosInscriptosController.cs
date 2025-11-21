using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroAbogados.Context;
using RegistroAbogados.Models;

namespace RegistroAbogados.Controllers
{
    public class AbogadosInscriptosController : ControllerBase
    {
            private readonly RegistroAbogadosContext _context;

            public AbogadosInscriptosController(RegistroAbogadosContext context)
            {
                _context = context;
            }

        [HttpPost("ValidarAbogado")]
        public async Task<ActionResult<bool>> ValidarAbogado([FromBody] AbogadoRequest request)
        {
            if (request == null)
                return BadRequest("Debe enviar los datos del abogado.");

            bool existe = await _context.AbogadosInscriptos.AnyAsync(a =>
                a.Tomo == request.Tomo &&
                a.Folio == request.Folio &&
                a.NroDocumento == request.NroDocumento &&
                a.Genero == request.Genero &&
                a.Nombre.Trim().ToLower() == request.Nombre.Trim().ToLower() &&
                a.Apellido.Trim().ToLower() == request.Apellido.Trim().ToLower()
            );

            return Ok(existe);
        }

    }
    }
