namespace DiscoveryService.Business.Mappers.Discovery
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.Models.Dto.Controllers.Discovery;

    public class DiscoveryGetDtoMapper
    {
        public DiscoveryGetDto ToDto(Discovery entity)
        {
            var dto = new DiscoveryGetDto();

            var mapperHelper = new MapperGetDtoHelper<Discovery, DiscoveryGetDto>();
            mapperHelper.ToDto(entity, dto);

            dto.Id = entity.Id;

            return dto;
        }
    }
}