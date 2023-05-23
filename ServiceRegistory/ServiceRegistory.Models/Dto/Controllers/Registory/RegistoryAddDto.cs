namespace ServiceRegistory.Models.Dto.Controllers.Discovery
{
    using ServiceRegistory.Models.Dto.Base;

    public class RegistoryAddDto : BaseAddDto
    {
        public string ServiceName { get; set; }

        public string GlobalAddress { get; set; }

        public string LocalAddress { get; set; }

        public int Port { get; set; }
    }
}