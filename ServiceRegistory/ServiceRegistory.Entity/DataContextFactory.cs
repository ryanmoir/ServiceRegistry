namespace ServiceRegistory.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private DbContextOptions<DataContext> options { get; }

        public DataContextFactory(DbContextOptions<DataContext> options)
        {
            this.options = options;
        }

        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext(this.options);
        }
    }
}
