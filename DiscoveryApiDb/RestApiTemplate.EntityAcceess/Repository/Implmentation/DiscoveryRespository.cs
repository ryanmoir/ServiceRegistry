namespace DiscoveryService.EntityAcceess.Repository.Implmentation
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.EntityAcceess.Repository.Interface;
    using DiscoveryService.EntityAcceess.UnitOfWork.Interface;

    public class DiscoveryRespository : GenericRepository<Discovery>, IDiscoveryRespository
    {
        public DiscoveryRespository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
