using Leonardo.Moreno.CORE.Contract.Data;
using Leonardo.Moreno.CORE.Contract.Model;
using Leonardo.Moreno.CORE.Mapper;
using Leonardo.Moreno.CORE.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace Leonardo.Moreno.CORE.Base
{
    public abstract class BaseService<TUow> where TUow : IApplicationUow
    {
        protected readonly TUow _uow;
        protected readonly ILogger _logger;

        public BaseService(TUow applicationUow, ILogger logger)
        {
            _logger = logger;
            _logger?.LogInformation($"Initializing service : {DateTime.UtcNow}");
            _uow = applicationUow;
        }

        protected void HandleSVCException(Exception pEx)
        {
            HandleSVCException(SvcResponse.GetVoidResponse(HttpStatusCode.InternalServerError), pEx);
        }

        protected void HandleSVCException(SvcResponse pResponse, Exception pEx)
        {
            List<string> errs = new List<string>();
            do
            {
                errs.Add(pEx.Message);
                pEx = pEx.InnerException;

            } while (pEx != null);

            HandleSVCException(pResponse, errs.ToArray());
        }
        //TODO: response generic error msg on prod mode
        protected void HandleSVCException(SvcResponse pResponse, params string[] pErrors)
        {
            string defaultMsg = "Internal Error at Service Layer. ";
            _logger?.LogError(defaultMsg, pErrors);
            pResponse.Errors.Add(defaultMsg);
            pResponse.Errors.AddRange(pErrors);
        }
    }

    public abstract class BaseService<TEntity, TDto> : BaseService<IApplicationUow> where TEntity : IEntity where TDto : class
    {
        protected readonly IMapperCore<TEntity, TDto> _mapper;

        public BaseService(IApplicationUow applicationUow, ILogger logger, IMapperCore<TEntity, TDto> mapperCore) : base(applicationUow, logger)
        {
            _mapper = mapperCore;
        }
    }
}
