using Financa.Api.AppServices.Interfaces;
using Financa.Api.Models.Lancamento;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoAppService _lancamentoService;

        public LancamentoController(ILancamentoAppService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<LancamentoDto>))]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _lancamentoService.ObterTodos();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaLancamentoDto))]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _lancamentoService.ObterPorId(id));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LancamentoDto))]
        public async Task<IActionResult> Post([FromBody] AdicionaLancamentoDto lancamento)
        {
            var resultado = await _lancamentoService.Adicionar(lancamento);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LancamentoDto))]
        public async Task<IActionResult> Put(Guid id, [FromBody] LancamentoDto lancamento)
        {
            var resultado = await _lancamentoService.Atualizar(id, lancamento);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _lancamentoService.Remover(id);
            return NoContent();
        }
    }
}
