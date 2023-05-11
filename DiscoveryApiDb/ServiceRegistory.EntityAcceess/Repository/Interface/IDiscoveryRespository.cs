namespace DiscoveryService.EntityAcceess.Repository.Interface
{
    using DiscoveryService.Entity.Tables;

    public interface IDiscoveryRespository : IGenericRespository<Discovery>
    {
        public Task<Discovery> GetByServiceName(string ServiceName);
    }
}
