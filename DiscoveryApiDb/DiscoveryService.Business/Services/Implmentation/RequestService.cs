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

            HttpMethod httpMeth;
            switch (request.Method)
            {
                case "Get":
                    httpMeth = HttpMethod.Get;
                    break;
                case "Post":
                    httpMeth = HttpMethod.Post;
                    break;
                case "Delete":
                    httpMeth = HttpMethod.Delete;
                    break;
                default:
                    throw new Exception("unsported http method type");
            }

            var requestWrapper = new RequestWrapper(request, httpMeth, new Uri(serviceUri));
            var client = new HttpClientHelper();
            var response = await client.SendAsync(requestWrapper);
            return response;
        }
    }
}