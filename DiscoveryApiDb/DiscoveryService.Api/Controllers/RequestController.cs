namespace DiscoveryService.Api.Controllers
{
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Business.Services.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<DiscoveryController> _logger;
        private readonly IRequestService requestService;
        private readonly IControllerHelper controllerHelper;

        public RequestController(ILogger<DiscoveryController> logger, IRequestService requestService, IControllerHelper controllerHelper)
        {
            this._logger = logger;
            this.requestService= requestService;
            this.controllerHelper = controllerHelper;
        }

        public async Task<IActionResult> ProcessRequest([FromHeader] Guid CorrelationId, [FromHeader] Guid RequestId)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrelationId, RequestId);
            if (!string.IsNullOrEmpty(errorStr))
                return BadRequest(errorStr);

            try
            {
                var response = await requestService.ProcessRequest(this.Request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}