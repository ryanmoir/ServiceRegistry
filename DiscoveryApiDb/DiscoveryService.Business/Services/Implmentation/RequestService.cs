namespace DiscoveryService.Business.Services.Implmentation
{
    using global::DiscoveryService.Business.Services.Interface;
    using HttpRequestWrapper;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class RequestService : IRequestService
    {
        public async Task<HttpResponseContainer> ProcessRequest(HttpRequest request)
        {
            var serviceName = string.Empty;
            var serviceUri = string.Empty;

            var headers = request.Headers.Where(x => x.Key == "ServiceName");
            if (headers.Any())
                serviceName = headers.First().Value;
            headers = request.Headers.Where(x => x.Key == "ServiceUri");
            if (headers.Any())
                serviceUri = headers.First().Value;
            if (string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(serviceUri))
                throw new Exception("requests missing service headers which are needed for the discovery service");
            
            var requestWrapper = new RequestWrapper(request, HttpMethod.Get, new Uri(serviceUri));
            var client = new HttpClientHelper();
            return await client.SendAsync(requestWrapper);
        }
    }
}