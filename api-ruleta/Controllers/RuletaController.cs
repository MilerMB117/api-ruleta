using System;
using Microsoft.AspNetCore.Mvc;
using api_ruleta.Models;

namespace api_ruleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : ControllerBase
    {
        private static readonly Random random = new Random();

        [HttpGet("generar")]
        public ActionResult<RuletaResultado> Generar()
        {
            int numero = random.Next(0, 37);
            string color = (numero % 2 == 0) ? "rojo" : "negro";
            return Ok(new RuletaResultado { Numero = numero, Color = color });
        }

        [HttpPost("premio")]
        public ActionResult<decimal> CalcularPremio([FromBody] PremioRequest request)
        {
            // Implementar lógica para calcular el premio basado en la apuesta y el resultado de la ruleta
            decimal premioCalculado = 0;  // Esto debe ser calculado en función de la lógica del juego

            // Ejemplo de cálculo de premio (esto debe ser ajustado según la lógica correcta):
            if (request.Apuesta.Equals($"{request.ResultadoRuleta.Numero}-{request.ResultadoRuleta.Color}", StringComparison.OrdinalIgnoreCase))
            {
                premioCalculado = request.MontoApostado * 3;
            }

            return Ok(premioCalculado);
        }
    }

    public class PremioRequest
    {
        public string Nombre { get; set; }
        public decimal MontoApostado { get; set; }
        public string Apuesta { get; set; }
        public RuletaResultado ResultadoRuleta { get; set; }
    }
}
