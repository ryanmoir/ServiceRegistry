using System.ComponentModel.DataAnnotations;

namespace DiscoveryService.Entity.Tables
{
    public class HeartBeat : ITable
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public long CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public long? DeletedBy { get; set; }

        [Required]
        public long ServiceId { get; set; }
    }
}