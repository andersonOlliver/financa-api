using Financa.Api.AppServices.Interfaces;
using Financa.Api.Authorization;
using Financa.Api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }


        [HttpPost("registrar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaUsuarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RegistrarAsync([FromBody] AdicionaUsuarioDto novoUsuario)
        {
            try
            {
                var resultado = await _authAppService.Registrar(novoUsuario);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("autenticar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> AutenticarAsync([FromBody] LoginRequestDto login)
        {
            try
            {
                var resultado = await _authAppService.Autenticar(login);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet("me")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetalhaUsuarioDto))]
        public IActionResult UsuarioAtual()
        {
            return Ok(Usuario);
        }
    }
}
