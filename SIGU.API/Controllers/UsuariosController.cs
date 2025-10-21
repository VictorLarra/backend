using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGU.API.Data;
using SIGU.API.Models;

namespace SIGU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
{
    private readonly SiguContext _context;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(SiguContext context, ILogger<UsuariosController> logger)
    {
        _context = context;
        _logger = logger;
    }

        // GET: api/Usuarios   <- ruta explícita para LISTAR
        // [HttpGet("")] // explícito: evita conflictos con la ruta {id}
        // public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        // {
        //     _logger.LogInformation("GetUsuarios invoked");
        //     var list = await _context.usuarios.ToListAsync();
        //     return Ok(list);
        // }

        // // GET: api/Usuarios/5  <- fuerza que id sea entero
        // [HttpGet("{id:int}")]
        // public async Task<ActionResult<Usuario>> GetUsuario(int id)
        // {
        //     _logger.LogInformation("GetUsuario invoked for id {Id}", id);
        //     var usuario = await _context.usuarios.FindAsync(id);
        //     if (usuario == null) return NotFound();
        //     return usuario;
        // }


// GET: api/Usuarios
[HttpGet("")] // explícito: evita conflictos con la ruta {id}
public async Task<ActionResult<IEnumerable<object>>> GetUsuarios()
{
    _logger.LogInformation("GetUsuarios invoked");

    var list = await _context.usuarios
        .Include(u => u.programa) // 👈 incluye la relación
        .Select(u => new
        {
            u.id,
            u.nombre,
            u.cedula,
            u.correo,
            u.rol,
            Programa = u.programa != null ? u.programa.nombre : null,
            tipoPrograma = u.tipoPrograma
        })
        .ToListAsync();

    return Ok(list);
}

// GET: api/Usuarios/5
[HttpGet("{id:int}")]
public async Task<ActionResult<object>> GetUsuario(int id)
{
    _logger.LogInformation("GetUsuario invoked for id {Id}", id);

    var usuario = await _context.usuarios
        .Include(u => u.programa)
        .Where(u => u.id == id)
        .Select(u => new
        {
            u.id,
            u.nombre,
            u.cedula,
            u.correo,
            u.rol,
            Programa = u.programa != null ? u.programa.nombre : null,
            tipoPrograma = u.tipoPrograma


        })
        .FirstOrDefaultAsync();

    if (usuario == null) return NotFound();

    return Ok(usuario);
}


        // METODO PARA BUSCAR USUARIO EN ESPECIFICO POR NOMBRE
   [HttpGet("buscar/{nombre}")]
public async Task<ActionResult<IEnumerable<Usuario>>> BuscarUsuario(string nombre)
{
    var usuarios = await _context.usuarios
        .Include(u => u.programa)
        .Where(u => u.nombre.ToLower().Contains(nombre.ToLower()))
        .ToListAsync();

    if (usuarios == null || usuarios.Count == 0)
    {
        return NotFound();
    }

    return Ok(usuarios);
}

//////////////////////////////
// GET: api/Usuarios/por-tipo/{tipoPrograma}
[HttpGet("por-tipo/{tipoPrograma}")]
public async Task<IActionResult> GetUsuariosPorTipo(string tipoPrograma)
{
    try
    {
        using (var connection = _context.Database.GetDbConnection())
        {
            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                // 🔹 Llamamos a la función PostgreSQL
                command.CommandText = "SELECT * FROM obtener_estudiantes_por_tipo(@tipo)";
                var parametro = command.CreateParameter();
                parametro.ParameterName = "@tipo";
                parametro.Value = tipoPrograma;
                command.Parameters.Add(parametro);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var listaUsuarios = new List<object>();

                    while (await reader.ReadAsync())
                    {
                        listaUsuarios.Add(new
                        {
                            Id = reader["id"],
                            Nombre = reader["nombre"],
                            Cedula = reader["cedula"],
                            Correo = reader["correo"],
                            Rol = reader["rol"],
                            ProgramaId = reader["programaid"],
                            TipoPrograma = reader["tipoPrograma"]
                        });
                    }

                    return Ok(listaUsuarios);
                }
            }
        }
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

//////////////////////////

        [HttpPost]
public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
{
            try
            {
                _context.usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario creado exitosamente" });
    }
    catch (Exception ex)
    {
        var inner = ex.InnerException != null ? ex.InnerException.Message : "Sin inner exception";
        return StatusCode(500, $"Error al crear usuario: {ex.Message} - {inner}");
    }
}



        [HttpPut("{id}")]
        // public IActionResult EditarUsuario(int id, [FromBody] Usuario usuario)
        // {
        //     var user = _context.usuarios.Find(id);
        //     if (user == null)
        //         return NotFound(new { message = "Usuario no encontrado" });

        //     user.nombre = usuario.nombre;
        //     user.cedula = usuario.cedula;
        //     user.correo = usuario.correo;
        //     user.rol = usuario.rol;
        //     user.programaid = usuario.programaid;

        //             _context.SaveChanges();

        //     return Ok(new { message = "Usuario actualizado correctamente" });
        // }
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest(new { message = "El ID no coincide." });
            }

            var usuarioExistente = await _context.usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            // Actualizar campos
            usuarioExistente.nombre = usuario.nombre;
            usuarioExistente.correo = usuario.correo;
            usuarioExistente.programaid = usuario.programaid;
            usuarioExistente.rol = usuario.rol;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el usuario", error = ex.Message });
            }
        }

[HttpDelete("{id}")]
public IActionResult EliminarUsuario(int id)
{
    var user = _context.usuarios.Find(id);
    if (user == null)
        return NotFound(new { message = "Usuario no encontrado" });

    _context.usuarios.Remove(user);
    _context.SaveChanges();

    return Ok(new { message = "Usuario eliminado correctamente" });
}

        // GET: api/usuarios/byCorreo/{correo}
        [HttpGet("byCorreo/{correo}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByCorreo(string correo)
        {
            var usuario = await _context.usuarios.FirstOrDefaultAsync(u => u.correo == correo);

            if (usuario == null)
                return NotFound();

            return usuario;
        }
    }
}
