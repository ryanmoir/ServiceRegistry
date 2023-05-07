namespace DiscoveryService.Business.Mappers.Discovery
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.Models.Dto.Controllers.Discovery;

    public class DiscoveryAddDtoMapper
    {
        public Discovery ToEntity(DiscoveryAddDto dto)
        {
            var entity = new Discovery();

            var mapperHelper = new MapperAddDtoHelper<Discovery, DiscoveryAddDto>();
            mapperHelper.ToTable(entity, dto);

            entity.ServiceName = dto.ServiceName;
            entity.GlobalAddress = dto.GlobalAddress;
            entity.LocalAddress = dto.LocalAddress;

            return entity;
        }
    }
}