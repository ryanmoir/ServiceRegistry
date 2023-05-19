using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceRegistory.Api.Attributes;

namespace ServiceRegistory.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class HeartBeatController : Controller
    {
        private readonly ILogger<HeartBeatController> Logger;

        public HeartBeatController(ILogger<HeartBeatController> logger)
        {
            this.Logger = logger;
        }

        [HttpGet]
        [LogApiRequest]
        [ApiVersion("1.0")]
        [Route("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}