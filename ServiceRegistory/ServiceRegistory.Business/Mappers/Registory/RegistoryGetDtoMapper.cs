using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceRegistory.Models.Dto.Controllers.Discovery;

namespace ServiceRegistory.Business.Mappers.Registory
{
    public class RegistoryGetDtoMapper
    {
        public RegistoryGetDto ToDto(Entity.Tables.Registory entity)
        {
            var dto = new RegistoryGetDto();

            dto.Id = entity.Id;
            dto.CreationDate = entity.CreationDate;
            dto.CreatedBy = entity.CreatedBy;
            dto.ServiceName = entity.ServiceName;
            dto.GlobalAddress = entity.GlobalAddress;
            dto.LocalAddress = entity.LocalAddress;
            dto.Port = entity.Port;
            dto.ServiceStatus = entity.ServiceStatus;

            return dto;
        }
    }
}