namespace ServiceRegistory.Entity.Tables
{
    using System.ComponentModel.DataAnnotations;

    public interface ITable
    {
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public long CreatedBy { get; set; }
    }
}