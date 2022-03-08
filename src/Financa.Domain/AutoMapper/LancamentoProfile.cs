using AutoMapper;
using Financa.Domain.Dtos.Lancamento;
using Financa.Domain.Entities;

namespace Financa.Domain.AutoMapper
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Lancamento, LancamentoDto>().ReverseMap().ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));
            CreateMap<Lancamento, DetalhaLancamentoDto>().ReverseMap().ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));
            CreateMap<AdicionaLancamentoDto, Lancamento>()
                .ForMember(c => c.Id, prop => prop.MapFrom(p => Guid.NewGuid()))
                                                          .ForMember(c => c.CategoriaId, prop => prop.MapFrom(p => p.Categoria.Id));

            CreateMap<AdicionaDespesaDto, Lancamento>()
                .ConstructUsing(model => new Lancamento(model.Valor,
                                                        model.Titulo,
                                                        model.Descricao,
                                                        TipoLancamento.Despesa,
                                                        model.Categoria.Id,
                                                        model.Cartao.Id));
        }
    }
}
