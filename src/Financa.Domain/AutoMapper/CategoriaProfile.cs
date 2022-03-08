using AutoMapper;
using Financa.Domain.Dtos;
using Financa.Domain.Entities;

namespace Financa.Domain.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>()
                .ReverseMap();
            CreateMap<Categoria, DetalhaCategoriaDto>();
            CreateMap<AdicionaCategoriaDto, Categoria>()
                .ForMember(c => c.Id, prop => prop.MapFrom(p => Guid.NewGuid()));
        }
    }
}
