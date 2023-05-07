using DiscoveryService.EntityAcceess.Repository.Interface;
using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
using DiscoveryService.Models.Dto.Controllers.HeartBeat;

namespace DiscoveryService.Business.Services.Interface
{
    public interface IHeartBeatService
    {
        abstract IHeartBeatRespository HeartBeatRespository { get; }
        abstract IUnitOfWork UnitOfWork { get; }
        public Task<long> AddHeartBeat(HeartBeatAddDto addDto);
    }
}