namespace ServiceRegistory.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Logging;
    using ServiceRegistory.Api.Attributes;
    using ServiceRegistory.Api.Helpers.Interface;
    using ServiceRegistory.Business.Services.Interface;
    using ServiceRegistory.Models.Dto.Controllers.Discovery;
    using System;
    using System.Threading.Tasks;


    /// <summary>
    /// Dont need a update endpoint as the service address should not be changing
    /// the only time it should change is if current one is shut down and a new one is spinned up
    /// in which case should follow below logid
    /// add endpoint - service started
    /// delete endpoint - service stoped
    /// add endpoinot - service started in new location
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RegistoryController : ControllerBase
    {
        private readonly ILogger<RegistoryController> _logger;
        private readonly IRegistoryService RegistoryService;
        private readonly IControllerHelper controllerHelper;

        public RegistoryController(ILogger<RegistoryController> logger, IRegistoryService registoryService, IControllerHelper controllerHelper)
        {
            this._logger = logger;
            this.RegistoryService = registoryService;
            this.controllerHelper = controllerHelper;
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("Add")]
        public async Task<IActionResult> Add([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid, [FromBody] RegistoryAddDto registoryAddDto)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            controllerHelper.SetUpReponseGuids(this, CorrolationGuid);
            if (!controllerHelper.IsDtoVald(registoryAddDto, out var errors))
            {
                return BadRequest(errors);
            }

            try
            {
                var newId = await RegistoryService.Add(registoryAddDto);
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
        public async Task<IActionResult> Get([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid, [FromQuery] int serviceId)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            controllerHelper.SetUpReponseGuids(this, CorrolationGuid);
            if (!controllerHelper.IsItemIdValid(serviceId))
            {
                return BadRequest("invalid service id");
            }

            try
            {
                var result = await RegistoryService.Get(serviceId);
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
        public async Task<IActionResult> Delete([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid, [FromQuery] int serviceId)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            controllerHelper.SetUpReponseGuids(this, CorrolationGuid);
            if (!controllerHelper.IsItemIdValid(serviceId))
            {
                return BadRequest("invalid service id");
            }

            try
            {
                await RegistoryService.Delete(serviceId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}