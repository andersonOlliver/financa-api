using AutoMapper;
using Financa.Api.Models.Lancamento;
using Financa.Domain.Entities;

namespace Financa.Api.AutoMapper
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Lancamento, LancamentoDto>().ReverseMap().ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));
            CreateMap<Lancamento, DetalhaLancamentoDto>().ReverseMap().ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));
            CreateMap<AdicionaLancamentoDto, Lancamento>().ForMember(c => c.Id, prop => prop.MapFrom(p => Guid.NewGuid()))
                                                          .ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));
        }
    }
}
