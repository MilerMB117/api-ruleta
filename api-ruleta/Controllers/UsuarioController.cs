using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_ruleta.Data;
using api_ruleta.Models;

namespace api_ruleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario usuario)
        {
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre.ToLower() == usuario.Nombre.ToLower());

            if (existingUser == null)
            {
                _context.Usuarios.Add(usuario);
            }
            else
            {
                existingUser.Saldo += usuario.Saldo;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("saldo")]
        public async Task<ActionResult<decimal>> ObtenerSaldo(string nombre)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre.ToLower() == nombre.ToLower());

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario.Saldo);
        }
    }
}
