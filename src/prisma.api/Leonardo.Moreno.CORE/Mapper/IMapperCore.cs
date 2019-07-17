using AutoMapper;
using Leonardo.Moreno.CORE.Contract.Model;
using System.Collections.Generic;

namespace Leonardo.Moreno.CORE.Mapper
{
    public interface IMapperCore<TEntity, TDto> //where TEntity : IEntity where TDto : IDto<IEntity>
    {
        void SetEntityToDtoMapConfiguration(IMapper pMapperConfig);
        TDto MapToDto(TEntity pEntity);
        IEnumerable<TDto> MapToDto(IEnumerable<TEntity> pEntities);
        TEntity MapToEntity(TDto pDto);
        IEnumerable<TEntity> MapToEntity(IEnumerable<TDto> pDto);
    }
    public interface IMapperCore
    {
        TOutputEntity MapEntity<TInputEntity, TOutputEntity>(TInputEntity pEntity, IMapper pMapperConfig = null);
        IEnumerable<TOutputEntity> MapEntity<TInputEntity, TOutputEntity>(IEnumerable<TInputEntity> pEntities, IMapper pMapperConfig = null);
        TBaseClass MapToBaseClass<TDerivedClass, TBaseClass>(TDerivedClass pEntity);
        IEnumerable<TBaseClass> MapToBaseClass<TDerivedClass, TBaseClass>(IEnumerable<TDerivedClass> pEntities);
    }
}
