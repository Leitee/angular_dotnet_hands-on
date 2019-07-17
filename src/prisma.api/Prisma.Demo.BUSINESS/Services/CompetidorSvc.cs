using Leonardo.Moreno.CORE;
using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Contract.Data;
using Leonardo.Moreno.CORE.Response;
using Microsoft.Extensions.Logging;
using Prisma.Demo.BUSINESS.Mappers;
using Prisma.Demo.MODEL.Dto;
using Prisma.Demo.MODEL.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Prisma.Demo.BUSINESS.Services
{
    public class CompetidorSvc : BaseService<Competidor, CompetidorDto>, ICompetidorSvc
    {
        public CompetidorSvc(
            IApplicationUow applicationUow,
            ILogger logger)
            : base(applicationUow, logger, new CompetidorMapper())
        {
        }

        public async Task<SvcSingleResponse<CompetidorDto>> CreateAsync(CompetidorDto pDto)
        {
            var response = new SvcSingleResponse<CompetidorDto>();

            try
            {
                var entity = _mapper.MapToEntity(pDto);
                var svcResul = await _uow.GetRepository<Competidor>().InsertAsync(entity);

                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "No se pudo realizar la operación.");
                    return response;
                }

                response.Data = _mapper.MapToDto(svcResul);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<SvcSingleResponse<bool>> DeleteAsync(int pId)
        {
            var response = new SvcSingleResponse<bool>();

            try
            {
                var entity = await _uow.GetRepository<Competidor>().GetByIdAsync(pId);
                if (entity == null)
                {
                    HandleSVCException(response, "No se pudo realizar la operación.");
                    return response;
                }

                await _uow.GetRepository<Competidor>().DeleteAsync(entity);
                response.Data = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<SvcListResponse<CompetidorDto>> GetAllAsync()
        {
            var response = new SvcListResponse<CompetidorDto>();

            try
            {
                var entity = await _uow.GetRepository<Competidor>().AllAsync(
                    null,
                    c => c.OrderBy(o => o.Id),
                    x => x.Include(c => c.Marca),
                    x => x.Include(c => c.ZonaDePrecio));

                response.Data = _mapper.MapToDto(entity);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<SvcSingleResponse<CompetidorDto>> GetByIdAsync(int pId)
        {
            var response = new SvcSingleResponse<CompetidorDto>();

            try
            {
                var svcResul = await _uow.GetRepository<Competidor>().FindAsync(
                    c => c.Id == pId,
                    x => x.Include(c => c.Marca),
                    x => x.Include(c => c.ZonaDePrecio));
                response.Data = _mapper.MapToDto(svcResul);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<SvcSingleResponse<bool>> UpdateAsync(CompetidorDto pDto)
        {
            var response = new SvcSingleResponse<bool>();

            try
            {
                var entity = _mapper.MapToEntity(pDto);
                await _uow.GetRepository<Competidor>().UpdateAsync(entity);
                response.Data = await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
