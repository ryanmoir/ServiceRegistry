using DiscoveryService.Models.Dto.Controllers.HeartBeat;

namespace DiscoveryService.Business.Mappers.HeartBeat
{
    public class HeartBeatAddDtoMapper
    {
        public Entity.Tables.HeartBeat ToEntity(HeartBeatAddDto dto)
        {
            var entity = new Entity.Tables.HeartBeat();

            var mapperHelper = new MapperAddDtoHelper<Entity.Tables.HeartBeat, HeartBeatAddDto>();
            mapperHelper.ToTable(entity, dto);

            entity.ServiceId = dto.ServiceId;

            return entity;
        }
    }
}