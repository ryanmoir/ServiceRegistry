namespace DiscoveryService.Entity.Tables
{
    using System.ComponentModel.DataAnnotations;

    public interface ITable
    {
        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public long? DeletedBy { get; set; }
    }
}