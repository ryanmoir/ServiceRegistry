namespace ServiceRegistory.Entity
{
    using ServiceRegistory.Entity.Tables;
    using Microsoft.EntityFrameworkCore;

    partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Discovery> Discovery { get; set; }
        public DbSet<Registory> Registory { get; set; }
    }
}
