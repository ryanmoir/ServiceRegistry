namespace DiscoveryService.Client
{
    using DiscoveryService.Client.Interface;
    using DiscoveryService.Models.Dto.Controllers.Discovery;
    using HttpRequestWrapper;
    using System.Threading.Tasks;

    public class DiscoveryClient : IDiscoveryClient, IRequestClient
    {
        private HttpClientHelper clientHelper;
        private string baseUri;
        private string BuildBaseDiscoveryontrollerString { get => baseUri + "api/v1/Discovery/"; }
        private string BuildBaseRequestControllerString { get => baseUri + "api/v1/Request/"; }

        public DiscoveryClient(string baseUri)
        {
            clientHelper = new HttpClientHelper();
            this.baseUri = baseUri;
        }

        public async Task<HttpResponseContainer> DiscoveryAdd(DiscoveryAddDto discoveryAddDto)
        {
            var request = new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseDiscoveryontrollerString + "Add"));
            return await clientHelper.SendAsync<DiscoveryAddDto>(request, discoveryAddDto);
        }

        public async Task<HttpResponseContainer> DiscoveryDelete(long discoveryId)
        {
            var request = new RequestWrapper(HttpMethod.Delete, new Uri(BuildBaseDiscoveryontrollerString + $"Delete?serviceId={discoveryId}"));
            return await clientHelper.SendAsync(request);
        }

        public async Task<HttpResponseContainer> DiscoveryGet(long discoveryId)
        {
            var request = new RequestWrapper(HttpMethod.Get, new Uri(BuildBaseDiscoveryontrollerString + $"Get?serviceId={discoveryId}"));
            return await clientHelper.SendAsync<DiscoveryGetDto>(request);
        }

        public async Task<HttpResponseContainer> DiscoveryUpdate(DiscoveryUpdateDto discoveryUpdateDto)
        {
            var request = new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseDiscoveryontrollerString + "Update"));
            return await clientHelper.SendAsync<DiscoveryUpdateDto>(request, discoveryUpdateDto);
        }

        public async Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper requestToFoward)
        {
            var request = new RequestWrapper(requestToFoward, HttpMethod.Post, new Uri(BuildBaseRequestControllerString + "ProcessRequest"));
            return await clientHelper.SendAsync<T>(request);
        }
    }
}