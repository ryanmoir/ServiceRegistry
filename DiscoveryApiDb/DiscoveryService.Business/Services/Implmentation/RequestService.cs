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
            var serviceDetails = await discoveryService.Get(ServiceName);
            if (serviceDetails == null)
                throw new Exception("No matching service found");

            //method
            HttpMethod? embeddedRequestMethod = null;
            var headers = request.Headers.Where(x => x.Key == "requestToEmbedMethod");
            if (!headers.Any())
                throw new Exception("missing requestToEmbedMethod header");
            var requestToEmbedMethodHeaderValue = headers.FirstOrDefault().Value.First();
            switch (requestToEmbedMethodHeaderValue.ToLower())
            {
                case "get":
                    embeddedRequestMethod = HttpMethod.Get;
                    break;
                case "post":
                    embeddedRequestMethod = HttpMethod.Post;
                    break;
                case "delete":
                    embeddedRequestMethod = HttpMethod.Delete;
                    break;
                default:
                    throw new Exception($"{requestToEmbedMethodHeaderValue} is not supported");
            }

            //uri
            Uri? embeddedRequestUri = null;
            headers = request.Headers.Where(x => x.Key == "requestToEmbedUri");
            if (!headers.Any())
                throw new Exception("missing requestToEmbedUri header");
            else
            {
                //this is due to request being set up so that they can ethier be sent here or direct to the intended service
                //so need to do bit of admin to make sure we creating the right uri
                var embeddedRequestUriStr = headers.FirstOrDefault().Value.First();
                var strSplit = embeddedRequestUriStr.Split("api/");
                if (strSplit.Length > 1)
                    embeddedRequestUri = new Uri(serviceDetails.GlobalAddress + strSplit[1]);
                else
                    embeddedRequestUri = new Uri(serviceDetails.GlobalAddress + strSplit[0]);
            }

            //body
            headers = request.Headers.Where(x => x.Key == "requestToEmbedBody");
            if (headers.Any())
            {

            }

            //headers

            //set up request to forward
            var requestWrapper = new RequestWrapper(embeddedRequestMethod, embeddedRequestUri);
            requestWrapper.Headers.Remove("CorrolationGuid");
            requestWrapper.Headers.Add("CorrolationGuid", request.Headers.Where(x => x.Key == "CorrolationGuid").First().Value.First());

            //send the request
            var client = new HttpClientHelper();
            return await client.SendAsync(requestWrapper);
        }
    }
}