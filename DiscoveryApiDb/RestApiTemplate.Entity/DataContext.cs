namespace DiscoveryService.Entity
{
    using Microsoft.EntityFrameworkCore;

    partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
