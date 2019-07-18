using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Externsions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prisma.Demo.BUSINESS.Services;
using Prisma.Demo.MODEL.Dto;
using System;
using System.Threading.Tasks;

namespace Prisma.Demo.API.Controllers
{

    public class CompetidorController : ApiBaseController
    {
        private readonly ICompetidorSvc _competidorSvc;

        public CompetidorController(
            ICompetidorSvc competidorSvc,
            ILogger<CompetidorController> logger) 
            : base(logger)
        {
            _competidorSvc = competidorSvc;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompetidor()
        {
            _logger?.LogInformation($"{nameof(GetCompetidor)}' se ha invocado");
            var response = await _competidorSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetidorById(int? id)
        {
            _logger?.LogInformation($"{nameof(GetCompetidorById)}' se ha invocado con id: {id}");
            if (ModelState.IsValid && id.HasValue)
            {
                var response = await _competidorSvc.GetByIdAsync(id.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetidor([FromBody] CompetidorDto competidorDto)
        {
            _logger?.LogInformation($"{nameof(CreateCompetidor)}' se ha invocado");
            if (ModelState.IsValid)
            {
                var response = await _competidorSvc.CreateAsync(competidorDto);
                return Created(new Uri($"{Request.Path}/{response.Data.Id}", UriKind.Relative), response);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetidor([FromBody] CompetidorDto competidorDto, int? id)
        {
            _logger?.LogInformation($"{nameof(UpdateCompetidor)}' se ha invocado con id: {id}");
            if (ModelState.IsValid && id.HasValue && id.Value == competidorDto.Id)
            {
                var response = await _competidorSvc.UpdateAsync(competidorDto);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetidor(int? id)
        {
            _logger?.LogInformation($"{nameof(DeleteCompetidor)}' se ha invocado con id: {id}");
            if (ModelState.IsValid && id.HasValue)
            {
                var response = await _competidorSvc.DeleteAsync(id.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }
    }
}