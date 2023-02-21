namespace DiscoveryService.Client.Interface
{
    using HttpRequestWrapper;

    public interface IRequestClient
    {
        Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper request);
    }
}