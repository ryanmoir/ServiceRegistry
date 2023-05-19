using Microsoft.EntityFrameworkCore;
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

        public async Task<Registory?> Get(string ServiceName)
        {
            return await table.Where(x => x.ServiceName == ServiceName).FirstOrDefaultAsync();
        }
    }
}