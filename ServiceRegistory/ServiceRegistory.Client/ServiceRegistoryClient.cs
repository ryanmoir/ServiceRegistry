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

        public async Task<HttpResponseContainer> RegistoryAdd(RegistoryAddDto registoryAddDto)
        {
            return await clientHelper.SendAsync<RegistoryAddDto>(MakeRegistoryAdd(registoryAddDto));
        }
        public async Task<HttpResponseContainer> RegistoryDelete(long registoryId)
        {
            return await clientHelper.SendAsync(MakeRegistoryDelete(registoryId));
        }
        public async Task<HttpResponseContainer> RegistoryGet(long registoryId)
        {
            return await clientHelper.SendAsync<RegistoryAddDto>(MakeRegistoryGet(registoryId));
        }

        public RequestWrapper MakeRegistoryAdd(RegistoryAddDto registoryAddDto)
        {
            return new RequestWrapper(HttpMethod.Post, new Uri(BuildBaseRegistoryControllerString + "Add"), registoryAddDto);
        }
        public RequestWrapper MakeRegistoryDelete(long registoryId)
        {
            return new RequestWrapper(HttpMethod.Delete, new Uri(BuildBaseRegistoryControllerString + $"Delete?serviceId={registoryId}"));
        }
        public RequestWrapper MakeRegistoryGet(long registoryId)
        {
            return new RequestWrapper(HttpMethod.Get, new Uri(BuildBaseRegistoryControllerString + $"Get?serviceId={registoryId}"));
        }

        public async Task<HttpResponseContainer> ProcessRequest<T>(RequestWrapper requestToFoward, string serviceName)
        {
            var request = new RequestWrapper(requestToFoward, HttpMethod.Post, new Uri(BuildBaseRequestControllerString + $"ProcessRequest?ServiceName={serviceName}"));
            return await clientHelper.SendAsync<T>(request);
        }
    }
}