using Carvices.BLL.DTO.Cars;
using Carvices.BLL.Interfaces;
using Carvices.DAL.Entities;
using Carvices.DAL.Interfaces;

namespace Carvices.BLL.Realization
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Guid> CreateAsync(CreateCarDTO createCar)
        {
            var createdCarId = await _carRepository.CreateAsync(new Car()
            {
                Name = createCar.Name,
                OwnerId = createCar.OwnerId,
                Status = createCar.CarStatus
            });
            return createdCarId;
        }

        public async Task<ICollection<GetMyCarsDTO>> GetMyCarsAsync(Guid userId)
        {
            return (await _carRepository.GetByOwnerIdAsync(userId))
                .Select(c => new GetMyCarsDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CarStatus = c.Status
                })
                .ToList();
        }
    }
}
