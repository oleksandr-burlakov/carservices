using Carvices.BLL.DTO.Services;
using Carvices.BLL.Interfaces;
using Carvices.DAL.Interfaces;

namespace Carvices.BLL.Realization
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> RegisterAsync(RegisterServiceDTO dto)
        {
            var result = await _repository.AddAsync(new DAL.Entities.Service()
            {
                Latitude = dto.Latitude,
                Longtitude = dto.Longtitude,
                Name = dto.Name,
            });
            return result;
        }
    }
}
