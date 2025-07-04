using Jqp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jqp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoController : ControllerBase
    {
        private readonly JokenpoService _jokenpoService;

        public JokenpoController(JokenpoService jokenpoService)
        {
            _jokenpoService = jokenpoService;
        }

        [HttpPost("jogarContraComputador")]
        public IActionResult JogarContraComputador([FromBody] string escolhaJogador)
        {
            if (string.IsNullOrEmpty(escolhaJogador) || !new[] { "Pedra", "Papel", "Tesoura" }.Contains(escolhaJogador))
            {
                return BadRequest("Escolha inválida. Use 'Pedra', 'Papel' ou 'Tesoura'.");
            }

            var resultado = _jokenpoService.Jogar(escolhaJogador);
            return Ok(resultado);
        }
    }
}
