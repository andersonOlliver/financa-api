using Financa.Api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected DetalhaUsuarioDto? Usuario => HttpContext.Items["User"] as DetalhaUsuarioDto;
    }
}
