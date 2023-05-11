using System.ComponentModel.DataAnnotations;

namespace ServiceRegistory.Entity.Tables
{
    public class HeartBeat : ITable
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public long CreatedBy { get; set; }

        [Required]
        public long ServiceId { get; set; }
    }
}