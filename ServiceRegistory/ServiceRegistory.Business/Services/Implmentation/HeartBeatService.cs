using ServiceRegistory.Business.Services.Interface;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;

namespace ServiceRegistory.Business.Services.Implmentation
{
    public class HeartBeatService : IHeartBeatService
    {
        private readonly IRegistoryRepository RegistoryRepository;
        private readonly IUnitOfWork UnitOfWork;

        public HeartBeatService(IRegistoryRepository registoryRepository, IUnitOfWork unitOfWork)
        {
            RegistoryRepository = registoryRepository;
            UnitOfWork = unitOfWork;
        }

        public void CheckForHeartBeats()
        {
            //get all records from repositories
            //try and get heartbeat from them
            //update db with heartbeat results
            throw new NotImplementedException();
        }
    }
}