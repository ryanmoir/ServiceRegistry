﻿namespace ServiceRegistory.Api.Helpers.Interface
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceRegistory.Models.Dto.Interface;
    using System;

    public interface IControllerHelper
    {
        string CheckCorrolationAndRequestId(Guid CorrelationId, Guid RequestId);
        bool IsDtoVald(IValidatableDto dto, out string errorsString);
        bool IsItemIdValid(long? id);
        void SetUpReponseGuids(ControllerBase controllerBase, Guid corrolationGuid);
    }
}
