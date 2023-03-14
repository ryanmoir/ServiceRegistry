namespace DiscoveryService.Client.Interface
{
    using DiscoveryService.Models.Dto.Controllers.Discovery;
    using HttpRequestWrapper;

    /// <summary>
    /// The sending and making split into 2 to allow support for sending the request to a third part e.g a discovery service
    /// </summary>
    public interface IDiscoveryClient
    {
        Task<HttpResponseContainer> DiscoveryAdd(DiscoveryAddDto discoveryAddDto);
        Task<HttpResponseContainer> DiscoveryDelete(long discoveryId);
        Task<HttpResponseContainer> DiscoveryUpdate(DiscoveryUpdateDto discoveryUpdateDto);
        Task<HttpResponseContainer> DiscoveryGet(long discoveryId);

        RequestWrapper MakeDiscoveryAdd();
        RequestWrapper MakeDiscoveryDelete(long discoveryId);
        RequestWrapper MakeDiscoveryGet(long discoveryId);
        RequestWrapper MakeDiscoveryUpdate();
    }
}