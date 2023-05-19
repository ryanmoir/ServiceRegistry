using ServiceRegistory.Entity.Tables;

namespace ServiceRegistory.EntityAcceess.Repository.Interface
{
    public interface IRegistoryRepository : IGenericRespository<Registory>
    {
        public Task<Registory?> Get(string ServiceName);
    }
}