namespace ServiceRegistory.Entity
{
    using Microsoft.EntityFrameworkCore;
    using ServiceRegistory.Entity.Tables;

    public partial class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registory>().HasKey(t => t.Id);
        }
    }
}