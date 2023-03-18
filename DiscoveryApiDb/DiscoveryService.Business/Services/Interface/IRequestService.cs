namespace DiscoveryService.Business.Services.Interface
{
    using HttpRequestWrapper;
    using Microsoft.AspNetCore.Http;

    public interface IRequestService
    {
        Task<HttpResponseContainer> ProcessRequest(HttpRequest request, string ServiceName);
    }
}