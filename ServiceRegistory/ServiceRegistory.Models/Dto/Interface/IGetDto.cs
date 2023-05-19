namespace ServiceRegistory.Models.Dto.Interface
{
    public interface IGetDto
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
    }
}