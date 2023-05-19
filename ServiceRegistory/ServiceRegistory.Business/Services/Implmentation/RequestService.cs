namespace ServiceRegistory.Business.Services.Implmentation
{
    using HttpRequestWrapper;
    using Microsoft.AspNetCore.Http;
    using ServiceRegistory.Business.Services.Interface;
    using ServiceRegistory.EntityAcceess.Repository.Interface;
    using System.Threading.Tasks;

    public class RequestService : IRequestService
    {
        private readonly IRegistoryRepository RegistoryRepository;

        public RequestService(IRegistoryRepository registoryService)
        {
            RegistoryRepository = registoryService;
        }

        public async Task<HttpResponseContainer> ProcessRequest(HttpRequest request, string ServiceName)
        {
            var serviceDetails = await RegistoryRepository.Get(ServiceName);
            if (serviceDetails == null)
                throw new Exception("No matching service found");

            var embeddedRequest = RequestWrapper.UnpackEmbeddedRequest(request, serviceDetails.GlobalAddress);
            var client = new HttpClientHelper();
            return await client.SendAsync(embeddedRequest);
        }
    }
}