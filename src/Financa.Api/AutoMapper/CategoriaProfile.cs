using AutoMapper;
using Financa.Api.Models;
using Financa.Domain.Entities;

namespace Financa.Api.AutoMapper
{
    public class CategoriaProfile: Profile
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
