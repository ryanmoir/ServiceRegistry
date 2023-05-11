namespace ServiceRegistory.Business.Services.Interface
{
    using ServiceRegistory.EntityAcceess.Repository.Interface;
    using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
    using ServiceRegistory.Models.Dto.Controllers.Discovery;

    public interface IDiscoveryService
    {
        abstract IDiscoveryRespository discoveryRepository { get; }
        abstract IUnitOfWork unitOfWork { get; }

        public Task<long> Add(DiscoveryAddDto addDto);
        public Task Delete(long id);
        public Task Update(DiscoveryUpdateDto updateDto);
        public Task<DiscoveryGetDto?> Get(long id);
        public Task<DiscoveryGetDto?> Get(string serviceName);
    }
}