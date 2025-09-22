// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SIGU.API.Data;
// using SIGU.API.Models;

// namespace SIGU.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class MatriculasController : ControllerBase
//     {
//         private readonly SiguContext _context;

//         public MatriculasController(SiguContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
//         {
//             return await _context.Matriculas
//                 .Include(m => m.Usuario)
//                 .Include(m => m.Grupo)
//                 .ToListAsync();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Matricula>> GetMatricula(int id)
//         {
//             var matricula = await _context.Matriculas
//                 .Include(m => m.Usuario)
//                 .Include(m => m.Grupo)
//                 .FirstOrDefaultAsync(m => m.Id == id);

//             if (matricula == null) return NotFound();
//             return matricula;
//         }

//         [HttpPost]
//         public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
//         {
//             _context.Matriculas.Add(matricula);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetMatricula), new { id = matricula.Id }, matricula);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
//         {
//             if (id != matricula.Id) return BadRequest();
//             _context.Entry(matricula).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteMatricula(int id)
//         {
//             var matricula = await _context.Matriculas.FindAsync(id);
//             if (matricula == null) return NotFound();
//             _context.Matriculas.Remove(matricula);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }
