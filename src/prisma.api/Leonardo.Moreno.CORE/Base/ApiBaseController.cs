using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Leonardo.Moreno.CORE.Base
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiBaseController(ILogger logger)
        {
            _logger = logger;
            _logger?.LogInformation($"Calling controller at: {DateTime.UtcNow}");
        }
    }
}