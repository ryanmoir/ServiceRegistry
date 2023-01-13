namespace DiscoveryService.Business.Mappers
{
    using DiscoveryService.Entity.Tables;
    using DiscoveryService.Models.Dto.Interface;

    /// <summary>
    /// used to do common IGetDto Mapper code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="D"></typeparam>
    public class MapperGetDtoHelper<T, D> where T : ITable where D : IGetDto
    {
        public void ToDto(T table, D dto)
        {
            dto.CreationDate = table.CreationDate;
            dto.CreatedBy = table.CreatedBy;

            dto.UpdateDate = table.UpdateDate;
            dto.UpdatedBy = table.UpdatedBy;

            dto.DeletedDate = table.DeletedDate;
            dto.DeletedBy = table.DeletedBy;

            dto.IsDeleted = table.IsDeleted;
        }
    }
}