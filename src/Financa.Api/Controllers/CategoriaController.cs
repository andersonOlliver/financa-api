using Financa.Api.AppServices.Interfaces;
using Financa.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _service;

        public CategoriaController(ICategoriaAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<CategoriaDto>))]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _service.ObterTodosAsync();
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaCategoriaDto))]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var resultado = await _service.ObterPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaDto))]
        public async Task<IActionResult> Adiciona([FromBody] AdicionaCategoriaDto categoria)
        {
            var resultado = await _service.AdicionaAsync(categoria);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaDto))]
        public async Task<IActionResult> Atualiza([FromRoute] Guid id, [FromBody] CategoriaDto categoria)
        {
            var resultado = await _service.AtualizaAsync(id, categoria);
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
