using AutoMapper;
using System.Collections.Generic;

namespace Leonardo.Moreno.CORE.Mapper
{
    public abstract class GenericMapperCore<TEntity, TDto> : IMapperCore<TEntity, TDto>
    {
        protected IMapper EntityToDtoMapConfiguration { get; set; }
        protected IMapper DtoToEntityMapConfiguration { get; set; }

        public GenericMapperCore()
        {
            EntityToDtoMapConfiguration = CreateEntityToDtoMapConfiguration();
            DtoToEntityMapConfiguration = CreateDtoToEntityMapConfiguration();
        }

        protected IMapper DefaultMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TEntity, TDto>().MaxDepth(2);
            }).CreateMapper();
        }

        protected abstract IMapper CreateEntityToDtoMapConfiguration();
        protected abstract IMapper CreateDtoToEntityMapConfiguration();

        public virtual void SetMapperConfiguration(IMapperConfigurationExpression configurationExpression)
        {
            //TODO: add expression param functionaity
            var expression = configurationExpression;
        }

        public virtual void SetEntityToDtoMapConfiguration(IMapper pMapperConfig)
        {
            EntityToDtoMapConfiguration = pMapperConfig;
        }

        public virtual void SetDtoToEntityMapConfiguration(IMapper pMapperConfig)
        {
            DtoToEntityMapConfiguration = pMapperConfig;
        }


        public virtual TDto MapToDto(TEntity entity)
        {
            if (entity == null) return default;
            return EntityToDtoMapConfiguration.Map<TDto>(entity);
        }

        public virtual IEnumerable<TDto> MapToDto(IEnumerable<TEntity> entity)
        {
            if (entity == null) return null;
            return EntityToDtoMapConfiguration.Map<IEnumerable<TDto>>(entity);
        }

        public virtual TEntity MapToEntity(TDto pDto)
        {
            if (pDto == null) return default;
            return DtoToEntityMapConfiguration.Map<TEntity>(pDto);
        }

        public virtual IEnumerable<TEntity> MapToEntity(IEnumerable<TDto> pDto)
        {
            if (pDto == null) return null;
            return DtoToEntityMapConfiguration.Map<IEnumerable<TEntity>>(pDto);
        }
    }

    public class GenericMapperCore : IMapperCore
    {
        protected virtual IMapper CreateCustomMap<TInputEntity, TOutputEntity>()
        {
            return new MapperConfiguration(c =>
            {
                c.ForAllMaps((typeMap, mappingExpression) => mappingExpression.MaxDepth(1));
                c.CreateMap<TInputEntity, TOutputEntity>();
            }).CreateMapper();
        }

        public virtual TOutputEntity MapEntity<TInputEntity, TOutputEntity>(TInputEntity pEntity, IMapper pMapperConfig = null)
        {
            if (pEntity == null) return default;
            var mapper = pMapperConfig ?? CreateCustomMap<TInputEntity, TOutputEntity>();
            return mapper.Map<TOutputEntity>(pEntity);
        }

        public virtual IEnumerable<TOutputEntity> MapEntity<TInputEntity, TOutputEntity>(IEnumerable<TInputEntity> pEntities, IMapper pMapperConfig = null)
        {
            if (pEntities == null) return null;
            var mapper = pMapperConfig ?? CreateCustomMap<TInputEntity, TOutputEntity>();
            return mapper.Map<IEnumerable<TOutputEntity>>(pEntities);
        }

        public virtual TBaseClass MapToBaseClass<TDerivedClass, TBaseClass>(TDerivedClass pEntity)
        {
            if (pEntity == null) return default;
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TDerivedClass, TBaseClass>();
            })
            .CreateMapper()
            .Map<TBaseClass>(pEntity);
        }

        public virtual IEnumerable<TBaseClass> MapToBaseClass<TDerivedClass, TBaseClass>(IEnumerable<TDerivedClass> pEntities)
        {
            if (pEntities == null) return null;
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TDerivedClass, TBaseClass>();
            })
            .CreateMapper()
            .Map<IEnumerable<TBaseClass>>(pEntities);
        }
    }
}
