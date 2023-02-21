namespace DiscoveryService.Client.Interface
{
    using DiscoveryService.Models.Dto.Controllers.Discovery;
    using HttpRequestWrapper;

    public interface IDiscoveryClient
    {
        Task<HttpResponseContainer> DiscoveryAdd(DiscoveryAddDto discoveryAddDto);
        Task<HttpResponseContainer> DiscoveryDelete(long discoveryId);
        Task<HttpResponseContainer> DiscoveryUpdate(DiscoveryUpdateDto discoveryUpdateDto);
        Task<HttpResponseContainer> DiscoveryGet(long discoveryId);
    }
}