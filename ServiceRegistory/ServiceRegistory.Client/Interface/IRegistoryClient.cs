namespace ServiceRegistory.Client.Interface
{
    using ServiceRegistory.Models.Dto.Controllers.Discovery;
    using HttpRequestWrapper;

    /// <summary>
    /// The sending and making split into 2 to allow support for sending the request to a third part e.g a discovery service
    /// </summary>
    public interface IRegistoryClient
    {
        Task<HttpResponseContainer> RegistoryAdd(DiscoveryAddDto discoveryAddDto);
        Task<HttpResponseContainer> RegistoryDelete(long discoveryId);
        Task<HttpResponseContainer> RegistoryUpdate(DiscoveryUpdateDto discoveryUpdateDto);
        Task<HttpResponseContainer> RegistoryGet(long discoveryId);

        RequestWrapper MakeRegistoryAdd(DiscoveryAddDto discoveryAddDto);
        RequestWrapper MakeRegistoryDelete(long discoveryId);
        RequestWrapper MakeRegistoryGet(long discoveryId);
        RequestWrapper MakeRegistoryUpdate(DiscoveryUpdateDto discoveryUpdateDto);
    }
}