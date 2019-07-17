using AutoMapper;
using Leonardo.Moreno.CORE.Mapper;
using Prisma.Demo.MODEL.Dto;
using Prisma.Demo.MODEL.Entity;
using System;

namespace Prisma.Demo.BUSINESS.Mappers
{
    public class CompetidorMapper : GenericMapperCore<Competidor, CompetidorDto>
    {
        protected override IMapper CreateDtoToEntityMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<CompetidorDto, Competidor>();

                c.CreateMap<MarcaDto, Marca>();
                c.CreateMap<ZonaDePrecioDto, ZonaDePrecio>();

            }).CreateMapper();
        }

        protected override IMapper CreateEntityToDtoMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Competidor, CompetidorDto>();

                c.CreateMap<Marca, MarcaDto>();
                c.CreateMap<ZonaDePrecio, ZonaDePrecioDto>();

            }).CreateMapper();
        }
    }
}
