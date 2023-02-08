namespace DiscoveryService.Api.Controllers
{
    using DiscoveryService.Api.Attributes;
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Business.Services.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using System;
    using DiscoveryService.Models.Dto.Controllers.Discovery;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DiscoveryController : ControllerBase
    {
        private readonly ILogger<DiscoveryController> _logger;
        private readonly IDiscoveryService discoveryService;
        private readonly IControllerHelper controllerHelper;

        public DiscoveryController(ILogger<DiscoveryController> logger, IDiscoveryService discoveryService, IControllerHelper controllerHelper)
        {
            this._logger = logger;
            this.discoveryService = discoveryService;
            this.controllerHelper = controllerHelper;
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("Add")]
        public async Task<IActionResult> Add([FromHeader] Guid CorrelationId, [FromHeader] Guid RequestId, [FromBody] DiscoveryAddDto discoveryAdDto)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrelationId, RequestId);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            if (!controllerHelper.IsDtoVald(discoveryAdDto, out var errors))
            {
                return BadRequest(errors);
            }

            try
            {
                var newId = await discoveryService.Add(discoveryAdDto);
                if (newId != 0)
                {
                    return Ok(newId);
                }
                else
                {
                    return NotFound("No id for new row was returned");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}