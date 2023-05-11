namespace ServiceRegistory.Models.Dto.Interface
{
    public interface IAddDto
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}