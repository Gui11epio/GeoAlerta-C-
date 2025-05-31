using GeoAlerta_C_.Application.DTOs.Request;
using GeoAlerta_C_.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoAlerta_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var usuarios = _usuarioService.ObterTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _usuarioService.ObterPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] UsuarioRequest request)
        {
            var usuario = _usuarioService.Criar(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UsuarioRequest request)
        {
            var sucesso = _usuarioService.Atualizar(id, request);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var sucesso = _usuarioService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
