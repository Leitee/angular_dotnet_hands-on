using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Externsions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prisma.Demo.BUSINESS.Services;
using System.Threading.Tasks;

namespace Prisma.Demo.API.Controllers
{

    public class CompetidorController : ApiBaseController
    {
        private readonly ICompetidorSvc _competidorSvc;

        public CompetidorController(ICompetidorSvc competidorSvc, ILogger logger) : base(logger)
        {
            _competidorSvc = competidorSvc;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await _competidorSvc.GetAllAsync();
            return response.ToHttpResponse();
        }
    }
}