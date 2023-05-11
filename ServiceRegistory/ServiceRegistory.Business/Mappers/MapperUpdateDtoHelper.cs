namespace DiscoveryService.Business.Mappers
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.Models.Dto.Interface;

    /// <summary>
    /// used to do common IUpdateDto Mapper code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="D"></typeparam>
    public class MapperUpdateDtoHelper<T, D> where T : IUpdatableTable where D : IUpdateDto
    {
        public void ToTable(T table, D dto)
        {
            table.UpdateDate = dto.UpdatedOn;
            table.UpdatedBy = dto.UpdatedBy;
        }
    }
}
