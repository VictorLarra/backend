using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGU.API.Data;
using SIGU.API.Models;

namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramasController : ControllerBase
    {
        private readonly SiguContext _context;

        public ProgramasController(SiguContext context)
        {
            _context = context;
        }

        // GET: api/programas
        // Devuelve todos los programas registrados
        [HttpGet("usuarios-programa")]
        public async Task<ActionResult<IEnumerable<object>>> GetProgramasConUsuarios()
        {
            var resultado = await _context.programas
                .Select(p => new
                {
                    ProgramaId = p.programaid,
                    ProgramaNombre = p.nombre,
                    Usuarios = p.usuarios.Select(u => new
                    {
                        
                        UsuarioId = u.id,
                        UsuarioNombre = u.nombre,
                        UsuarioCorreo = u.correo,
                        UsuarioRol = u.rol
                    }).ToList()
                })
                .ToListAsync();

            return Ok(resultado);
        }
    }
}