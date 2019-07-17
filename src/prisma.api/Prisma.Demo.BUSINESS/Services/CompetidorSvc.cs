using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Contract.Data;
using Leonardo.Moreno.CORE.Response;
using Microsoft.Extensions.Logging;
using Prisma.Demo.BUSINESS.Mappers;
using Prisma.Demo.MODEL.Dto;
using Prisma.Demo.MODEL.Entity;
using System;
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
            throw new NotImplementedException();
        }

        public async Task<SvcSingleResponse<bool>> DeleteAsync(CompetidorDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<SvcListResponse<CompetidorDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SvcSingleResponse<CompetidorDto>> GetByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }

        public async Task<SvcSingleResponse<bool>> UpdateAsync(CompetidorDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
