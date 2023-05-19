using ServiceRegistory.Models.Dto.Controllers.Discovery;

namespace ServiceRegistory.Business.Mappers.Registory
{
    public class RegistoryGetDtoMapper
    {
        public RegistoryGetDto ToDto(Entity.Tables.Registory entity)
        {
            var dto = new RegistoryGetDto();

            var mapperHelper = new MapperGetDtoHelper<Entity.Tables.Registory, RegistoryGetDto>();
            mapperHelper.ToDto(entity, dto);

            dto.Id = entity.Id;
            dto.ServiceName = entity.ServiceName;
            dto.GlobalAddress = entity.GlobalAddress;
            dto.LocalAddress = entity.LocalAddress;
            dto.Port = entity.Port;
            dto.ServiceStatus = entity.ServiceStatus;

            return dto;
        }
    }
}