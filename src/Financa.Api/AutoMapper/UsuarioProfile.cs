using AutoMapper;
using Financa.Api.Models.Usuario;
using Financa.Domain.Entities;

namespace Financa.Api.AutoMapper
{
    public class UsuarioProfile: Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();

            CreateMap<Usuario, DetalhaUsuarioDto>();

            CreateMap<AdicionaUsuarioDto, Usuario>()
                .ConstructUsing(model => new Usuario(model.Nome, model.Email, model.Senha))
                .AfterMap((add, usuario) => usuario.AplicarSenha(add.Senha));
                
        }
    }
}
