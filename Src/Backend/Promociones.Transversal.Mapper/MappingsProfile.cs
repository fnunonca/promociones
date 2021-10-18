using System;
using AutoMapper;
using Promociones.Domain.Entity;
using Promociones.Application.DTO;

namespace Promociones.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Promocion, PromocionDto>().ReverseMap();
            

        }
    }
}
