namespace ServiceRegistory.Entity
{
    using Microsoft.EntityFrameworkCore;
    using ServiceRegistory.Entity.Tables;

    partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Registory> Registory { get; set; }
    }
}
