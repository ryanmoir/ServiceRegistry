namespace ServiceRegistory.EntityAcceess.UnitOfWork.Interface
{
    using ServiceRegistory.Entity;

    public interface IUnitOfWork
    {
        DataContext Context { get; }
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}