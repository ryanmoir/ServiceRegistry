namespace DiscoveryService.Business.Services.Implmentation
{
    using global::DiscoveryService.Business.Services.Interface;
    using System.Threading.Tasks;

    public class DiscoveryService : IDiscoveryService
    {
        public EntityAcceess.Repository.Interface.IDiscoveryRespository discoveryRepository => throw new NotImplementedException();

        public EntityAcceess.UnitOfWork.Interface.IUnitOfWork unitOfWork => throw new NotImplementedException();

        public Task<long> Add(Models.Dto.Controllers.Discovery.DiscoveryAddDto addDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Dto.Controllers.Discovery.DiscoveryGetDto?> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Models.Dto.Controllers.Discovery.DiscoveryUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}