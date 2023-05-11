namespace ServiceRegistory.Business.Mappers
{
    using ServiceRegistory.Entity.Tables;
    using ServiceRegistory.Models.Dto.Interface;

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
        }
    }
}