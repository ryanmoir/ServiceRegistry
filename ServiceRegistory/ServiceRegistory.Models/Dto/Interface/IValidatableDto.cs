namespace ServiceRegistory.Models.Dto.Interface
{
    public interface IValidatableDto
    {
        public bool Validate(out List<string> validationErrros);
    }
}
