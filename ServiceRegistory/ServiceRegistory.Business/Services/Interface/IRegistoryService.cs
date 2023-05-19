using ServiceRegistory.Entity;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
using ServiceRegistory.Models.Dto.Controllers.Discovery;

namespace ServiceRegistory.Business.Services.Interface
{
    public interface IRegistoryService
    {
        public IRegistoryRepository RegistoryRepository { get; }
        public IUnitOfWork UnitOfWork { get; }

        public Task<long> Add(RegistoryAddDto addDto);
        public Task Delete(long id);
        public Task<RegistoryGetDto?> Get(long id);
        public Task Update(long id, ServiceStatus status);
    }
}