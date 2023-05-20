using ServiceRegistory.Models.Dto.Controllers.Discovery;

namespace ServiceRegistory.Business.Mappers.Registory
{
    public class RegistoryAddDtoMapper
    {
        public Entity.Tables.Registory ToEntity(RegistoryAddDto dto)
        {
            var entity = new Entity.Tables.Registory();

            entity.CreationDate = dto.CreatedOn;
            entity.CreatedBy = dto.CreatedBy;
            entity.ServiceName = dto.ServiceName;
            entity.GlobalAddress = dto.GlobalAddress;
            entity.LocalAddress = dto.LocalAddress;
            entity.Port = dto.Port;
            entity.ServiceStatus = dto.ServiceStatus;

            return entity;
        }
    }
}