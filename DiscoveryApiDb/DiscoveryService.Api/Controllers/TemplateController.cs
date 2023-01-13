namespace DiscoveryService.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DiscoveryService.Api.Attributes;
    using System.Threading.Tasks;

    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TemplateController : ControllerBase
    {
        private readonly ILogger<TemplateController> _logger;

        public TemplateController(ILogger<TemplateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [LogApiRequest]
        [Route("Test")]
        public  async Task<IActionResult> test([FromQuery] int i, [FromQuery] int t)
        {
            this._logger.LogDebug("Logged as debug - controller");
            this._logger.LogInformation("Logged as information - controller");
            this._logger.LogError("Logged as error - controller");

            return Ok();
        }
    }
}