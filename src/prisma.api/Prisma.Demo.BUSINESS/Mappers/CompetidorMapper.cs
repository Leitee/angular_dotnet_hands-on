using AutoMapper;
using Leonardo.Moreno.CORE.Mapper;
using Prisma.Demo.MODEL.Dto;
using Prisma.Demo.MODEL.Entity;
using System;

namespace Prisma.Demo.BUSINESS.Mappers
{
    public class CompetidorMapper : GenericMapperCore<Competidor, CompetidorDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
