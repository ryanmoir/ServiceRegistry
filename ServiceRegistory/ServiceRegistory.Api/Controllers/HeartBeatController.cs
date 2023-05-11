using ServiceRegistory.Api.Attributes;
using ServiceRegistory.Api.Helpers.Interface;
using ServiceRegistory.Business.Services.Interface;
using ServiceRegistory.Models.Dto.Controllers.HeartBeat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ServiceRegistory.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class HeartBeatController : Controller
    {
        private readonly ILogger<HeartBeatController> _logger;
        private readonly IHeartBeatService heartBeatService;
        private readonly IControllerHelper controllerHelper;

        public HeartBeatController(ILogger<HeartBeatController> logger, IHeartBeatService heartBeatService, IControllerHelper controllerHelper)
        {
            this._logger = logger;
            this.heartBeatService = heartBeatService;
            this.controllerHelper = controllerHelper;
        }

        [HttpGet]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public IActionResult GetHeartBeat()
        {
            return Ok();
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public async Task<IActionResult> ReceiveHeartBeat([FromHeader] Guid CorrolationGuid, [FromHeader] Guid RequestGuid, [FromBody] HeartBeatAddDto heartBeatAddDto)
        {
            var errorStr = controllerHelper.CheckCorrolationAndRequestId(CorrolationGuid, RequestGuid);
            if (!string.IsNullOrEmpty(errorStr))
            {
                return BadRequest(errorStr);
            }

            controllerHelper.SetUpReponseGuids(this, CorrolationGuid);
            if (!controllerHelper.IsDtoVald(heartBeatAddDto, out var errors))
            {
                return BadRequest(errors);
            }

            try
            {
                var id = await heartBeatService.AddHeartBeat(heartBeatAddDto);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("CheckHeartBeats")]
        public IActionResult CheckHeartBeats()
        {
            //to be called by a azure function or something along those lines
            //remove any services that have not had heatbeats in x time
            throw new NotImplementedException();
        }
    }
}