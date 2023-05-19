namespace ServiceRegistory.Entity
{
    using ServiceRegistory.Entity.Tables;
    using Microsoft.EntityFrameworkCore;

    public partial class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>().HasKey(t => t.Id);
            modelBuilder.Entity<Registory>().HasKey(t => t.Id);
        }
    }
}