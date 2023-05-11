namespace ServiceRegistory.EntityAcceess.Repository.Interface
{
    using ServiceRegistory.Entity.Tables;

    public interface IDiscoveryRespository : IGenericRespository<Discovery>
    {
        public Task<Discovery> GetByServiceName(string ServiceName);
    }
}
