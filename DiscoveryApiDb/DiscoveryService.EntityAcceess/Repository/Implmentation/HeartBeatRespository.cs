using DiscoveryService.Entity.Tables;
using DiscoveryService.EntityAcceess.Repository.Interface;
using DiscoveryService.EntityAcceess.UnitOfWork.Interface;

namespace DiscoveryService.EntityAcceess.Repository.Implmentation
{
    public class HeartBeatRespository : GenericRepository<HeartBeat>, IHeartBeatRespository
    {
        public HeartBeatRespository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}