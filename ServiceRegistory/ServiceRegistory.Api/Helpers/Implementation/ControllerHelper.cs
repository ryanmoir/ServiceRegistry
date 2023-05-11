namespace DiscoveryService.Api.Helper
{
    using DiscoveryService.Api.Helpers.Interface;
    using DiscoveryService.Models.Dto.Interface;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ControllerHelper : IControllerHelper
    {
        public string CheckCorrolationAndRequestId(Guid CorrelationId, Guid RequestId)
        {
            if (CorrelationId == Guid.Empty)
                return "missing corrolation id";

            if (RequestId == Guid.Empty)
                return "missing request id";

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

        public void SetUpReponseGuids(ControllerBase controllerBase, Guid corrolationGuid)
        {
            controllerBase.Response.Headers.Add("CorrolationGuid", corrolationGuid.ToString());
            controllerBase.Response.Headers.Add("RequestGuid", Guid.NewGuid().ToString());
        }
    }
}