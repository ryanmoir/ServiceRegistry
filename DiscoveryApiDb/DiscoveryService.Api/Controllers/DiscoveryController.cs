namespace DiscoveryService.Api.Controllers
{
    using DiscoveryService.Api.Attributes;
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Business.Services.Interface;
    using DiscoveryService.Models.Dto.Controllers.Discovery;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

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
                return Ok(newId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("Get")]
        public async Task<IActionResult> Get([FromHeader] Guid CorrelationId, [FromHeader] Guid RequestId, [FromQuery] int serviceId)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrelationId, RequestId);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            if (!controllerHelper.IsItemIdValid(serviceId))
            {
                return BadRequest("invalid service id");
            }

            try
            {
                var result = await discoveryService.Get(serviceId);
                if (result == null)
                {
                    return NotFound("No row found with service id of " + serviceId);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromHeader] Guid CorrelationId, [FromHeader] Guid RequestId, [FromQuery] int serviceId)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrelationId, RequestId);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            if (!controllerHelper.IsItemIdValid(serviceId))
            {
                return BadRequest("invalid service id");
            }

            try
            {
                await discoveryService.Delete(serviceId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("Update")]
        public async Task<IActionResult> Update([FromHeader] Guid CorrelationId, [FromHeader] Guid RequestId, [FromBody] DiscoveryUpdateDto discoveryUpdateDto)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrelationId, RequestId);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            if (!controllerHelper.IsDtoVald(discoveryUpdateDto, out var errors))
            {
                return BadRequest(errors);
            }

            try
            {
                await discoveryService.Update(discoveryUpdateDto);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}