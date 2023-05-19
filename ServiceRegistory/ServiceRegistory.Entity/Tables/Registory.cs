namespace ServiceRegistory.Entity.Tables
{
    public class Registory : ITable
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public long CreatedBy { get; set; }

        public string ServiceName { get; set; }

        public string GlobalAddress { get; set; }

        public string LocalAddress { get; set; }

        public int Port { get; set; }

        public ServiceStatus ServiceStatus { get; set; }
    }
}