using Financa.Api.AppServices.Interfaces;
using Financa.Api.Authorization;
using Financa.Api.Models.Lancamento;
using Microsoft.AspNetCore.Mvc;


namespace Financa.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : BaseController
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
            var resultado = await _lancamentoService.ObterTodos(Usuario!.Id);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaLancamentoDto))]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _lancamentoService.ObterPorId(id));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LancamentoDto))]
        public async Task<IActionResult> Adicionar([FromBody] AdicionaLancamentoDto lancamento)
        {
            var resultado = await _lancamentoService.Adicionar(lancamento, Usuario?.Id);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LancamentoDto))]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] LancamentoDto lancamento)
        {
            var resultado = await _lancamentoService.Atualizar(id, lancamento);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _lancamentoService.Remover(id);
            return NoContent();
        }
    }
}
