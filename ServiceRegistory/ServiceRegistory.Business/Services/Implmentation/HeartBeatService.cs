using ServiceRegistory.Business.Mappers.HeartBeat;
using ServiceRegistory.Business.Services.Interface;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
using ServiceRegistory.Models.Dto.Controllers.HeartBeat;

namespace ServiceRegistory.Business.Services.Implmentation
{
    public class HeartBeatService : IHeartBeatService
    {
        public IHeartBeatRespository HeartBeatRespository { get; internal set; }
        public IUnitOfWork UnitOfWork { get; internal set; }
        public IDiscoveryRespository DiscoveryRespository { get; set; }

        public HeartBeatService(IHeartBeatRespository heartBeatRespository, IDiscoveryRespository discoveryRespository, IUnitOfWork unitOfWork)
        {
            HeartBeatRespository = heartBeatRespository;
            DiscoveryRespository = discoveryRespository;
            UnitOfWork = unitOfWork;
        }

        public async Task<long> AddHeartBeat(HeartBeatAddDto addDto)
        {
            var entity = new HeartBeatAddDtoMapper().ToEntity(addDto);
            var service = await DiscoveryRespository.GetById(entity.Id);
            if (service == null)
                throw new Exception("Service not found");
            else if (service.IsDeleted)
                throw new Exception("Service has been deleted");

            await HeartBeatRespository.Insert(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
}