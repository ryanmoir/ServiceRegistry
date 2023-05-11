namespace ServiceRegistory.Models.Dto.Interface
{
    public interface IUpdateDto
    {
        public long Id { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}