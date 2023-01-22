using Carvices.DAL.Entities;
using Carvices.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carvices.DAL.Realization
{
    public class CarRepository : ICarRepository
    {
        private readonly EFContext _context;
        public CarRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Car car)
        {
            var returnCar = (await _context.Cars.AddAsync(car));
            await _context.SaveChangesAsync();
            return returnCar.Entity.Id;
        }

        public async Task<ICollection<Car>> GetByOwnerIdAsync(Guid ownerId)
        {
            return (await _context.Cars
                .Where(c => c.OwnerId == ownerId)
                .ToListAsync());
        }
    }
}
