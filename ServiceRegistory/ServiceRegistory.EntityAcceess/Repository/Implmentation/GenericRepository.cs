namespace DiscoveryService.EntityAcceess.Repository.Implmentation
{
    using DiscoveryService.Entity;
    using DiscoveryService.EntityAcceess.Repository.Interface;
    using DiscoveryService.EntityAcceess.UnitOfWork.Interface;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<T> : IGenericRespository<T> where T : class
    {
        private DataContext _context;
        public DbSet<T> table;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T?> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
        }

        public void Update(T obj)
        {
            try
            {
                table.Attach(obj);
            }
            catch (InvalidOperationException)
            {
                table.Remove(obj); //need to remove incase we tried to do update twice on same entity
                table.Attach(obj);
            }
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task Delete(object id)
        {
            T? existing = await table.FindAsync(id);

            if (existing == null)
            {
                throw new KeyNotFoundException(id + " not present in table");
            }

            table.Remove(existing);
        }
    }
}