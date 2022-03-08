using Financa.Api.Authorization;
using Financa.Domain.Dtos.Cartao;
using Financa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartaoController : BaseController
    {
        private readonly ICartaoService _service;

        public CartaoController(ICartaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ListaCartaoDto>))]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _service.ObterTodosAsync();
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaCartaoDto))]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var resultado = await _service.ObterPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaCartaoDto))]
        public async Task<IActionResult> Adiciona([FromBody] AdicionaCartaoDto model)
        {
            var resultado = await _service.AdicionaAsync(model, Usuario!.Id);
            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaCartaoDto))]
        public async Task<IActionResult> Atualiza([FromRoute] Guid id, [FromBody] DetalhaCartaoDto model)
        {
            var resultado = await _service.AtualizaAsync(id, model);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
