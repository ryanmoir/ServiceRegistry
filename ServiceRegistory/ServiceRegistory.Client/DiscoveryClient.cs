namespace ServiceRegistory.Client
{
    using ServiceRegistory.Client.Interface;
    using ServiceRegistory.Models.Dto.Controllers.Discovery;
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
            return await clientHelper.SendAsync<DiscoveryAddDto>(MakeDiscoveryAdd(discoveryAddDto));
        }
        public async Task<HttpResponseContainer> DiscoveryDelete(long discoveryId)
        {
            return await clientHelper.SendAsync(MakeDiscoveryDelete(discoveryId));
        }
        public async Task<HttpResponseContainer> DiscoveryGet(long discoveryId)
        {
            return await clientHelper.SendAsync<DiscoveryGetDto>(MakeDiscoveryGet(discoveryId));
        }
        public async Task<HttpResponseContainer> DiscoveryUpdate(DiscoveryUpdateDto discoveryUpdateDto)
        {
            return await clientHelper.SendAsync<DiscoveryUpdateDto>(MakeDiscoveryUpdate(discoveryUpdateDto));
        }

        public RequestWrapper MakeDiscoveryAdd(DiscoveryAddDto discoveryAddDto)
        {
            return new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseDiscoveryontrollerString + "Add"), discoveryAddDto);
        }
        public RequestWrapper MakeDiscoveryDelete(long discoveryId)
        {
            return new RequestWrapper(HttpMethod.Delete, new Uri(BuildBaseDiscoveryontrollerString + $"Delete?serviceId={discoveryId}"));
        }
        public RequestWrapper MakeDiscoveryGet(long discoveryId)
        {
            return new RequestWrapper(HttpMethod.Get, new Uri(BuildBaseDiscoveryontrollerString + $"Get?serviceId={discoveryId}"));
        }
        public RequestWrapper MakeDiscoveryUpdate(DiscoveryUpdateDto discoveryUpdateDto)
        {
            return new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseDiscoveryontrollerString + "Update"), discoveryUpdateDto);
        }

        public async Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper requestToFoward, string serviceName)
        {
            var request = new RequestWrapper(requestToFoward, HttpMethod.Post, new Uri(BuildBaseRequestControllerString + $"ProcessRequest?ServiceName={serviceName}"));
            return await clientHelper.SendAsync<T>(request);
        }
    }
}