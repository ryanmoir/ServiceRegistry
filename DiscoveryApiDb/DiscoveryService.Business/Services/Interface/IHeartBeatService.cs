using DiscoveryService.EntityAcceess.Repository.Interface;
using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
using DiscoveryService.Models.Dto.Controllers.HeartBeat;

namespace DiscoveryService.Business.Services.Interface
{
    public interface IHeartBeatService
    {
        abstract IHeartBeatRespository HeartBeatRespository { get; }
        abstract IUnitOfWork unitOfWork { get; }
        public Task<long> AddHeartBeat(HeartBeatAddDto addDto);
    }
}