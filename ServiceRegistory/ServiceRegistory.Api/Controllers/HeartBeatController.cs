using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceRegistory.Api.Attributes;
using ServiceRegistory.Business.Services.Interface;
using System;

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
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public IActionResult CheckForHeartBeats()
        {
            throw new NotImplementedException();
        }
    }
}