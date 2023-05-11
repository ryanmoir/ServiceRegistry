using System.ComponentModel.DataAnnotations;

namespace DiscoveryService.Entity.Tables
{
    public interface IUpdatableTable : ITable
    {
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public long? UpdatedBy { get; set; }

        public long? DeletedBy { get; set; }
    }
}