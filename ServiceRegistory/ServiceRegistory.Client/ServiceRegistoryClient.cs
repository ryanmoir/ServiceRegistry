namespace ServiceRegistory.Client
{
    using ServiceRegistory.Client.Interface;
    using ServiceRegistory.Models.Dto.Controllers.Discovery;
    using HttpRequestWrapper;
    using System.Threading.Tasks;

    public class ServiceRegistoryClient : IRegistoryClient, IRequestClient
    {
        private HttpClientHelper clientHelper;
        private string baseUri;
        private string BuildBaseRegistoryControllerString { get => baseUri + "api/v1/Registory/"; }
        private string BuildBaseRequestControllerString { get => baseUri + "api/v1/Request/"; }

        public ServiceRegistoryClient(string baseUri)
        {
            clientHelper = new HttpClientHelper();
            this.baseUri = baseUri;
        }

        public async Task<HttpResponseContainer> RegistoryAdd(DiscoveryAddDto discoveryAddDto)
        {
            return await clientHelper.SendAsync<DiscoveryAddDto>(MakeRegistoryAdd(discoveryAddDto));
        }
        public async Task<HttpResponseContainer> RegistoryDelete(long discoveryId)
        {
            return await clientHelper.SendAsync(MakeRegistoryDelete(discoveryId));
        }
        public async Task<HttpResponseContainer> RegistoryGet(long discoveryId)
        {
            return await clientHelper.SendAsync<DiscoveryGetDto>(MakeRegistoryGet(discoveryId));
        }
        public async Task<HttpResponseContainer> RegistoryUpdate(DiscoveryUpdateDto discoveryUpdateDto)
        {
            return await clientHelper.SendAsync<DiscoveryUpdateDto>(MakeRegistoryUpdate(discoveryUpdateDto));
        }

        public RequestWrapper MakeRegistoryAdd(DiscoveryAddDto discoveryAddDto)
        {
            return new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseRegistoryControllerString + "Add"), discoveryAddDto);
        }
        public RequestWrapper MakeRegistoryDelete(long discoveryId)
        {
            return new RequestWrapper(HttpMethod.Delete, new Uri(BuildBaseRegistoryControllerString + $"Delete?serviceId={discoveryId}"));
        }
        public RequestWrapper MakeRegistoryGet(long discoveryId)
        {
            return new RequestWrapper(HttpMethod.Get, new Uri(BuildBaseRegistoryControllerString + $"Get?serviceId={discoveryId}"));
        }
        public RequestWrapper MakeRegistoryUpdate(DiscoveryUpdateDto discoveryUpdateDto)
        {
            return new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseRegistoryControllerString + "Update"), discoveryUpdateDto);
        }

        public async Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper requestToFoward, string serviceName)
        {
            var request = new RequestWrapper(requestToFoward, HttpMethod.Post, new Uri(BuildBaseRequestControllerString + $"ProcessRequest?ServiceName={serviceName}"));
            return await clientHelper.SendAsync<T>(request);
        }
    }
}