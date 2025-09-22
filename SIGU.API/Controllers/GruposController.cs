// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SIGU.API.Data;
// using SIGU.API.Models;

// namespace SIGU.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class GruposController : ControllerBase
//     {
//         private readonly SiguContext _context;

//         public GruposController(SiguContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupos()
//         {
//             return await _context.Grupos
//                 .Include(g => g.Materia)
//                 .Include(g => g.Docente)
//                 .ToListAsync();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Grupo>> GetGrupo(int id)
//         {
//             var grupo = await _context.Grupos
//                 .Include(g => g.Materia)
//                 .Include(g => g.Docente)
//                 .FirstOrDefaultAsync(g => g.Id == id);

//             if (grupo == null) return NotFound();
//             return grupo;
//         }

//         [HttpPost]
//         public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
//         {
//             _context.Grupos.Add(grupo);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetGrupo), new { id = grupo.Id }, grupo);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutGrupo(int id, Grupo grupo)
//         {
//             if (id != grupo.Id) return BadRequest();
//             _context.Entry(grupo).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteGrupo(int id)
//         {
//             var grupo = await _context.Grupos.FindAsync(id);
//             if (grupo == null) return NotFound();
//             _context.Grupos.Remove(grupo);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }
