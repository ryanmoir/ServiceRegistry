namespace DiscoveryService.Business.Services.Implmentation
{
    using global::DiscoveryService.Business.Mappers.Discovery;
    using global::DiscoveryService.Business.Services.Interface;
    using System.Threading.Tasks;

    public class DiscoveryService : IDiscoveryService
    {
        public EntityAcceess.Repository.Interface.IDiscoveryRespository discoveryRepository => throw new NotImplementedException();

        public EntityAcceess.UnitOfWork.Interface.IUnitOfWork unitOfWork => throw new NotImplementedException();

        public async Task<long> Add(Models.Dto.Controllers.Discovery.DiscoveryAddDto addDto)
        {
            var entity = new DiscoveryAddDtoMapper().ToEntity(addDto);
            await discoveryRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
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