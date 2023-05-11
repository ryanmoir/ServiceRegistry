namespace DiscoveryService.Client.Interface
{
    using HttpRequestWrapper;

    /// <summary>
    /// This is not intended to be sent to a third party as this send reqiest tp reqiest cpmtrp;;er pm discovery service which would act itself as a third party between services
    /// </summary>
    public interface IRequestClient
    {
        Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper request, string serviceName);
    }
}