﻿namespace ServiceRegistory.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ServiceRegistory.Api.Attributes;
    using ServiceRegistory.Api.Helpers.Interface;
    using ServiceRegistory.Business.Services.Interface;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestService requestService;
        private readonly IControllerHelper controllerHelper;

        public RequestController(ILogger<RequestController> logger, IRequestService requestService, IControllerHelper controllerHelper)
        {
            this._logger = logger;
            this.requestService = requestService;
            this.controllerHelper = controllerHelper;
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("ProcessRequest")]
        public async Task<IActionResult> ProcessRequestPost([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid, [FromQuery] string ServiceName)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
                return BadRequest(errorStr);

            controllerHelper.SetUpReponseGuids(this, CorrolationGuid);
            try
            {
                var response = await requestService.ProcessRequest(this.Request, ServiceName);
                var responseContent = await response.Response.Content.ReadAsStringAsync();
                if (response.IsSuccess)
                    return Ok(responseContent);
                else
                    return BadRequest(responseContent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}