using DiscoveryService.Business.Mappers.HeartBeat;
using DiscoveryService.Business.Services.Interface;
using DiscoveryService.EntityAcceess.Repository.Interface;
using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
using DiscoveryService.Models.Dto.Controllers.HeartBeat;

namespace DiscoveryService.Business.Services.Implmentation
{
    public class HeartBeatService : IHeartBeatService
    {
        public IHeartBeatRespository HeartBeatRespository { get; internal set; }

        public IUnitOfWork unitOfWork { get; internal set; }

        public HeartBeatService(IHeartBeatRespository heartBeatRespository, IUnitOfWork unitOfWork)
        {
            this.HeartBeatRespository = heartBeatRespository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<long> AddHeartBeat(HeartBeatAddDto addDto)
        {
            var entity = new HeartBeatAddDtoMapper().ToEntity(addDto);
            await HeartBeatRespository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
}