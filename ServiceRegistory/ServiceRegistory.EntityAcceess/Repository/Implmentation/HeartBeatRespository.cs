using ServiceRegistory.Entity.Tables;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;

namespace ServiceRegistory.EntityAcceess.Repository.Implmentation
{
    public class HeartBeatRespository : GenericRepository<HeartBeat>, IHeartBeatRespository
    {
        public HeartBeatRespository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}