namespace DiscoveryService.Api.Helpers.Interface
{
    using DiscoveryService.Models.Dto.Interface;
    using System;

    public interface IControllerHelper
    {
        string CheckCorrolationAndRequestId(Guid CorrelationId, Guid RequestId);
        bool IsDtoVald(IValidatableDto dto, out string errorsString);
        bool IsItemIdValid(long? id);
    }
}
