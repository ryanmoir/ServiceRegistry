namespace ServiceRegistory.EntityAcceess.Repository.Implmentation
{
    using ServiceRegistory.Entity.Tables;
    using ServiceRegistory.EntityAcceess.Repository.Interface;
    using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
    using Microsoft.EntityFrameworkCore;

    public class DiscoveryRespository : GenericRepository<Discovery>, IDiscoveryRespository
    {
        public DiscoveryRespository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Discovery> GetByServiceName(string ServiceName)
        {
            return await table.Where(x => x.ServiceName == ServiceName).FirstOrDefaultAsync();
        }
    }
}