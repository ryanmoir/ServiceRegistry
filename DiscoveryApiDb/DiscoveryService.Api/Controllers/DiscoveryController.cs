namespace DiscoveryService.Api.Controllers
{
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Business.Services.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

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
    }
}