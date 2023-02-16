namespace DiscoveryService.Api.Controllers
{
    using DiscoveryService.Api.Attributes;
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

        [HttpGet]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
                return BadRequest(errorStr);

            try
            {
                var response = await requestService.ProcessRequest(this.Request);
                if (response.IsSuccess)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}