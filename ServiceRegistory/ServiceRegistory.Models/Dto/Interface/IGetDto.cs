namespace ServiceRegistory.Models.Dto.Interface
{
    public interface IGetDto
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}