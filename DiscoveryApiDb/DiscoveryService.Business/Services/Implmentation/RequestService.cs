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
            var serviceMethod = string.Empty;

            var headers = request.Headers.Where(x => x.Key == "ServiceName");
            if (headers.Any())
                serviceName = headers.First().Value;
            headers = request.Headers.Where(x => x.Key == "ServiceUri");
            if (headers.Any())
                serviceUri = headers.First().Value;
            headers = request.Headers.Where(x => x.Key == "ServiceMethod");
            if (headers.Any())
                serviceMethod = headers.First().Value;
            if (string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(serviceUri) || string.IsNullOrEmpty(serviceMethod))
                throw new Exception("request missing service headers which are needed for the discovery service");

            HttpMethod? meth;
            switch (serviceMethod.ToLower())
            {
                case "get":
                    meth = HttpMethod.Get;
                    break;
                case "post":
                    meth = HttpMethod.Post;
                    break;
                case "delete":
                    meth = HttpMethod.Delete;
                    break;
                default:
                    throw new Exception($"{serviceMethod} is not supported");
            }

            var requestWrapper = new RequestWrapper(request, meth, new Uri(serviceUri));
            var client = new HttpClientHelper();
            return await client.SendAsync(requestWrapper);
        }
    }
}