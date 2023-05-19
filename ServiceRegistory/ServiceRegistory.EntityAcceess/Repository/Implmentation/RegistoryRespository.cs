using ServiceRegistory.Entity.Tables;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;

namespace ServiceRegistory.EntityAcceess.Repository.Implmentation
{
    public class RegistoryRespository : GenericRepository<Registory>, IRegistoryRepository
    {
        public RegistoryRespository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}