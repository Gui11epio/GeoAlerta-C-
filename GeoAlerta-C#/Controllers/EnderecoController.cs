using GeoAlerta_C_.Application.DTOs.Request;
using GeoAlerta_C_.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoAlerta_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var enderecos = _enderecoService.ObterTodos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var endereco = _enderecoService.ObterPorId(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] EnderecoRequest request)
        {
            var endereco = _enderecoService.Criar(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] EnderecoRequest request)
        {
            var sucesso = _enderecoService.Atualizar(id, request);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var sucesso = _enderecoService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
