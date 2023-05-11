namespace DiscoveryService.EntityAcceess.Repository.Implmentation
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.EntityAcceess.Repository.Interface;
    using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
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