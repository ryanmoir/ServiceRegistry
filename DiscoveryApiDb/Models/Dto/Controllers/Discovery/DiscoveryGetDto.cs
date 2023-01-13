namespace DiscoveryService.Models.Dto.Controllers.Discovery
{
    using DiscoveryService.Models.Dto.Interface;

    public class DiscoveryGetDto : IGetDto
    {
        public long Id { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

        public long? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}