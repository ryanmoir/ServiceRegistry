namespace ServiceRegistory.EntityAcceess.UnitOfWork.Implmentation
{
    using ServiceRegistory.Entity;
    using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContextFactory dataContextFactory)
        {
            _context = dataContextFactory.CreateDbContext(new string[0]);
        }

        public DataContext Context
        {
            get { return _context; }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}