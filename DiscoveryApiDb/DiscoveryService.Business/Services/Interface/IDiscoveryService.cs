namespace DiscoveryService.Business.Services.Interface
{
    using DiscoveryService.EntityAcceess.Repository.Interface;
    using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
    using DiscoveryService.Models.Dto.Controllers.Discovery;

    public interface IDiscoveryService
    {
        abstract IDiscoveryRespository discoveryRepository { get; }
        abstract IUnitOfWork unitOfWork { get; }

        public Task<long> Add(DiscoveryAddDto addDto);
        public Task Delete(long id);
        public Task Update(DiscoveryUpdateDto updateDto);
        public Task<DiscoveryGetDto?> Get(long id);
    }
}