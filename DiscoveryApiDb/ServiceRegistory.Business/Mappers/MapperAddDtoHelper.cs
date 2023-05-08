namespace DiscoveryService.Business.Mappers
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.Models.Dto.Interface;

    /// <summary>
    /// used to do common IAddDto Mapper code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="D"></typeparam>
    public class MapperAddDtoHelper<T, D> where T : ITable where D : IAddDto
    {
        public void ToTable(T table, D dto)
        {
            table.CreationDate = dto.CreatedOn;
            table.CreatedBy = dto.CreatedBy;
        }
    }
}