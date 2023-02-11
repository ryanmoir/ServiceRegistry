namespace DiscoveryService.Models.Dto.Controllers.Discovery
{
    using DiscoveryService.Models.Dto.Base;

    public class DiscoveryUpdateDto : BaseUpdateDto
    {
        public string ServiceName { get; set; }
        public string GlobalAddress { get; set; }
        public string LocalAddress { get; set; }
    }
}