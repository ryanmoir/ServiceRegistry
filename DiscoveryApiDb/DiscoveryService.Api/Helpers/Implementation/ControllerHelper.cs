namespace DiscoveryService.Api.Helper
{
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Models.Dto.Interface;
    using System;

    public class ControllerHelper : IControllerHelper
    {
        public string CheckCorrolationAndRequestId(Guid CorrelationId, Guid RequestId)
        {
            if (CorrelationId == Guid.Empty)
            {
                return "missinng corrolation id";
            }

            if (RequestId == Guid.Empty)
            {
                return "missinng request id";
            }

            return string.Empty;
        }

        public bool IsDtoVald(IValidatableDto dto, out string errorsString)
        {
            errorsString = string.Empty;
            var valid = dto.Validate(out var validateErrors);
            if (!valid)
            {
                errorsString = (string.Join(",", validateErrors));
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsItemIdValid(long? id)
        {
            return id.HasValue && id != 0 ? true : false;
        }
    }
}