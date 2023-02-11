namespace DiscoveryService.Business.Mappers.Discovery
{
    using DiscoveryService.Models.Dto.Controllers.Discovery;
    using DiscoveryService.Entity.Tables;

    public class DiscoveryUpdateDtoMapper
    {
        public Discovery ToEntity(DiscoveryUpdateDto dto)
        {
            var entity = new Discovery();

            var mapperHelper = new MapperUpdateDtoHelper<Discovery, DiscoveryUpdateDto>();
            mapperHelper.ToTable(entity, dto);

            entity.Id = dto.Id;
            entity.ServiceName = dto.ServiceName;
            entity.GlobalAddress = dto.GlobalAddress;
            entity.LocalAddress = dto.LocalAddress;

            return entity;
        }
    }
}