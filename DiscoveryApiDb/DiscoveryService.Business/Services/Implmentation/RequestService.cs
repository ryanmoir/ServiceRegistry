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
                //https://localhost:7272/swagger/index.html
                //https://localhost:7272/api/v1/Discovery/Get?serviceId=1
                var embeddedRequestUriStr = headers.FirstOrDefault().Value.First();
                var strSplit = embeddedRequestUriStr.Split("api/");
                embeddedRequestUri = new Uri("https://localhost:7272/api/" + strSplit[1]);
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