using GeoAlerta_C_.Application.DTOs.Request;
using GeoAlerta_C_.Application.DTOs.Response;
using GeoAlerta_C_.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoAlerta_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _alertaService;

        public AlertaController(AlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpPost]
        public ActionResult<AlertaResponse> Calcular([FromBody] DadosClimaticosRequest request)
        {
            try
            {
                var alerta = _alertaService.CalcularAlerta(request);
                return Ok(alerta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
