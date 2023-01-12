namespace DiscoveryService.Models.Dto.Base
{
    using DiscoveryService.Models.Dto.Interface;

    public class BaseUpdateDto : IUpdateDto, IValidatableDto
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual bool Validate(out List<string> validationErrros)
        {
            validationErrros = new List<string>();

            if (Id == 0)
            {
                validationErrros.Add("Id of 0 supplied");
            }
            if (UpdatedBy == 0)
            {
                validationErrros.Add("UpdatedBy cannot be 0");
            }
            if (UpdatedOn == DateTime.MinValue)
            {
                validationErrros.Add("UpdatedOn must have a value");
            }
            if (IsDeleted)
            {
                validationErrros.Add("Cannot set IsDeleted to deleted using a updatedDto");
            }

            return validationErrros.Count == 0 ? true : false;
        }
    }
}
