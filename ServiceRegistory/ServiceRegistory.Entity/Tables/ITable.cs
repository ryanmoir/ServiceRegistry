namespace ServiceRegistory.Entity.Tables
{
    public interface ITable
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public long CreatedBy { get; set; }
    }
}