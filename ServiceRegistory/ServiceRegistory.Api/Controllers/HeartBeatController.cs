using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceRegistory.Api.Attributes;
using ServiceRegistory.Business.Services.Interface;
using System.Threading.Tasks;

namespace ServiceRegistory.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class HeartBeatController : Controller
    {
        private readonly IHeartBeatService HeartBeatService;
        private readonly ILogger<HeartBeatController> Logger;

        public HeartBeatController(ILogger<HeartBeatController> logger, IHeartBeatService heartBeatService)
        {
            Logger = logger;
            HeartBeatService = heartBeatService;
        }

        [HttpGet]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        /// <summary>
        /// might be worth changing this so that it doesnt wait till the end by default to give a response
        /// instead mabye should just kick off the work and then return ok
        /// or queue up the work somewhere with a due time
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public async Task<IActionResult> CheckForHeartBeats()
        {
            var errors = await HeartBeatService.CheckForHeartBeats();
            if (errors != null)
                return BadRequest(errors);      
            else
                return Ok();
        }
    }
}