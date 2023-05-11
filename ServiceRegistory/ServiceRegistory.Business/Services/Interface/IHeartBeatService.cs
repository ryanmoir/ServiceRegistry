using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
using ServiceRegistory.Models.Dto.Controllers.HeartBeat;

namespace ServiceRegistory.Business.Services.Interface
{
    public interface IHeartBeatService
    {
        abstract IHeartBeatRespository HeartBeatRespository { get; }
        abstract IUnitOfWork UnitOfWork { get; }
        public Task<long> AddHeartBeat(HeartBeatAddDto addDto);
    }
}