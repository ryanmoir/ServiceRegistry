namespace DiscoveryService.EntityAcceess.Repository.Interface
{
    public interface IGenericRespository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(object id);
        Task Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
    }
}
