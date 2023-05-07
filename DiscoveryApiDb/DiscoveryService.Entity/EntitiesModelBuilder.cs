namespace DiscoveryService.Entity
{
    using DiscoveryService.Entity.Tables;
    using Microsoft.EntityFrameworkCore;

    public partial class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>().HasKey(t => t.Id);
        }
    }
}
