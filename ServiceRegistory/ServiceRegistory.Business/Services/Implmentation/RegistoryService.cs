using ServiceRegistory.Business.Mappers.Registory;
using ServiceRegistory.Business.Services.Interface;
using ServiceRegistory.Entity;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
using ServiceRegistory.Models.Dto.Controllers.Discovery;

namespace ServiceRegistory.Business.Services.Implmentation
{
    public class RegistoryService : IRegistoryService
    {
        public IRegistoryRepository RegistoryRepository { get; internal set; }

        public IUnitOfWork UnitOfWork { get; internal set; }

        public RegistoryService(IRegistoryRepository registoryRepository, IUnitOfWork unitOfWork)
        {
            this.RegistoryRepository = registoryRepository;
            this.UnitOfWork = unitOfWork;
        }

        public async Task<long> Add(RegistoryAddDto addDto)
        {
            var entity = new RegistoryAddDtoMapper().ToEntity(addDto);
            await RegistoryRepository.Insert(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(long id)
        {
            await RegistoryRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<RegistoryGetDto?> Get(long id)
        {
            var entity = await RegistoryRepository.GetById(id);
            if (entity != null)
            {
                return new RegistoryGetDtoMapper().ToDto(entity);
            }
            return null;
        }

        public async Task Update(long id, ServiceStatus status)
        {
            var entity = await RegistoryRepository.GetById(id);
            if (entity != null)
            {
                entity.ServiceStatus = status.ToString();
                RegistoryRepository.Update(entity);
                await UnitOfWork.SaveChangesAsync();
            }
        }
    }
}