namespace DiscoveryService.Entity
{
    using DiscoveryService.Entity.Tables;
    using Microsoft.EntityFrameworkCore;

    partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Discovery> Discovery { get; set; }
    }
}
