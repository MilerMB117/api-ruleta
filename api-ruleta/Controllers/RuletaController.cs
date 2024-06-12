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
            // Verificar si la apuesta es válida
            if (EsApuestaValida(request.Apuesta, request.ResultadoRuleta))
            {
                // Implementar lógica para calcular el premio basado en la apuesta y el resultado de la ruleta
                decimal premioCalculado = CalcularPremio(request.MontoApostado, request.Apuesta, request.ResultadoRuleta);
                return Ok(premioCalculado);
            }
            else
            {
                return BadRequest("La apuesta no es válida.");
            }
        }

        private bool EsApuestaValida(string apuesta, RuletaResultado resultadoRuleta)
        {
            // Verificar si la apuesta es válida según la lógica del juego
            // Por ejemplo, podrías verificar si la apuesta coincide con el resultado de la ruleta
            // Aquí implementa la lógica adecuada para tu juego de la ruleta
            return true; // Por ahora, simplemente devuelve true para todos los casos
        }

        private decimal CalcularPremio(decimal montoApostado, string apuesta, RuletaResultado resultadoRuleta)
        {
            // Implementar la lógica para calcular el premio basado en la apuesta y el resultado de la ruleta
            // Por ahora, simplemente retorna un monto fijo como ejemplo
            return 100; // Retorna un premio de 100 (esto es un ejemplo)
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
