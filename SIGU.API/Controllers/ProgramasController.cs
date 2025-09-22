// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SIGU.API.Data;
// using SIGU.API.Models;

// namespace SIGU.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ProgramasController : ControllerBase
//     {
//         private readonly SiguContext _context;

//         public ProgramasController(SiguContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Programa>>> GetProgramas()
//         {
//             return await _context.programas.ToListAsync();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Programa>> GetPrograma(int id)
//         {
//             var programa = await _context.programas.FindAsync(id);
//             if (programa == null) return NotFound();
//             return programa;
//         }

//         [HttpPost]
//         public async Task<ActionResult<Programa>> PostPrograma(Programa programa)
//         {
//             _context.programas.Add(programa);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetPrograma), new { id = programa.Id }, programa);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutPrograma(int id, Programa programa)
//         {
//             if (id != programa.Id) return BadRequest();
//             _context.Entry(programa).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeletePrograma(int id)
//         {
//             var programa = await _context.programas.FindAsync(id);
//             if (programa == null) return NotFound();
//             _context.programas.Remove(programa);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }
