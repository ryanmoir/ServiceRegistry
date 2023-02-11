namespace DiscoveryService.Business.Services.Interface
{
    public interface IRequestService
    {
        Task ProcessGetRequest();
        Task ProcessPostRequest();
        Task ProcessDeleteRequest();
    }
}