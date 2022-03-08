using AutoMapper;
using Financa.Domain.Dtos.Cartao;
using Financa.Domain.Entities;

namespace Financa.Domain.AutoMapper
{
    public class CartaoProfile: Profile
    {
        public CartaoProfile()
        {
            CreateMap<AdicionaCartaoDto, Cartao>()
                .ForMember(c => c.Id, prop => prop.MapFrom(p => Guid.NewGuid()));
            CreateMap<Cartao, DetalhaCartaoDto>().ReverseMap();
            CreateMap<Cartao, ListaCartaoDto>();
        }
    }
}
