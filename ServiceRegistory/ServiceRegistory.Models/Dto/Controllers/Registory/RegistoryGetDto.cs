namespace ServiceRegistory.Models.Dto.Controllers.Discovery
{
    using ServiceRegistory.Models.Dto.Interface;
    using System;

    public class RegistoryGetDto : IGetDto
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public long CreatedBy { get; set; }

        public string ServiceName { get; set; }

        public string GlobalAddress { get; set; }

        public string LocalAddress { get; set; }

        public int Port { get; set; }

        public string ServiceStatus { get; set; }
    }
}