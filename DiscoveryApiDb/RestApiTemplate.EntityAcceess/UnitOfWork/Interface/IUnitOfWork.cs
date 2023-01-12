namespace DiscoveryService.EntityAcceess.UnitOfWork.Interface
{
    using DiscoveryService.Entity;

    public interface IUnitOfWork
    {
        DataContext Context { get; }
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}