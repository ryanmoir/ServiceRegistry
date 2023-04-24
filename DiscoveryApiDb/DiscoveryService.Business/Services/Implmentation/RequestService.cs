namespace DiscoveryService.Business.Services.Implmentation
{
    using global::DiscoveryService.Business.Services.Interface;
    using HttpRequestWrapper;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class RequestService : IRequestService
    {
        private readonly IDiscoveryService discoveryService;

        public RequestService(IDiscoveryService _discoveryService)
        {
            discoveryService = _discoveryService;
        }

        public async Task<HttpResponseContainer> ProcessRequest(HttpRequest request, string ServiceName)
        {
            var embeddedRequest = RequestWrapper.UnpackEmbeddedRequest(request);

            //need suppport for adding a url prefix to it before can use discovery service for this bit
            /*
            var serviceDetails = await discoveryService.Get(ServiceName);
            if (serviceDetails == null)
                throw new Exception("No matching service found");
            */

            //send the request
            var client = new HttpClientHelper();
            return await client.SendAsync(embeddedRequest);
        }
    }
}