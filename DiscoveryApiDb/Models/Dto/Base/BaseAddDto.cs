namespace DiscoveryService.Models.Dto.Base
{
    using DiscoveryService.Models.Dto.Interface;

    public class BaseAddDto : IAddDto, IValidatableDto
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual bool Validate(out List<string> validationErrros)
        {
            validationErrros = new List<string>();

            if (CreatedBy == 0)
            {
                validationErrros.Add("CreatedBy supplied was 0");
            }
            if (CreatedOn == DateTime.MinValue)
            {
                validationErrros.Add("CreatedOn supplied was minvalue");
            }

            return validationErrros.Count == 0 ? true : false;
        }
    }
}