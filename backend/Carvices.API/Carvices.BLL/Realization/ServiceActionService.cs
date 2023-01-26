using Carvices.BLL.DTO.ServiceActions;
using Carvices.BLL.Interfaces;
using Carvices.DAL.Interfaces;
using Microsoft.Identity.Client;

namespace Carvices.BLL.Realization
{
    public class ServiceActionService : IServiceActionService
    {
        private readonly IServiceActionRepository _repository;
        public ServiceActionService(IServiceActionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddAsync(AddServiceActionDTO dto)
        {
            return (await _repository.AddAsync(new DAL.Entities.ServiceAction()
            {
                IsFree = dto.IsFree,
                Description = dto.Description,
                HourEstimation = dto.HourEstimation,
                Name = dto.Name,
                Price = dto.Price,
                ServiceId = dto.ServiceId
            }));
        }

        public async Task<ICollection<GetServiceActionByServiceDTO>> GetByServiceAsync(Guid serviceId)
        {
            return (await _repository.GetByServiceIdAsync(serviceId))
                .Select(sa => new GetServiceActionByServiceDTO()
                {
                    Id= sa.Id,
                    Name = sa.Name
                })
                .ToList();
        }
    }
}
