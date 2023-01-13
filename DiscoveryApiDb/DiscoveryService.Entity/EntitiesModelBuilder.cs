namespace DiscoveryService.Entity
{
    using Microsoft.EntityFrameworkCore;
    using DiscoveryService.Entity.Tables;

    public partial class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>().HasKey(t => t.Id);
        }
    }
}
