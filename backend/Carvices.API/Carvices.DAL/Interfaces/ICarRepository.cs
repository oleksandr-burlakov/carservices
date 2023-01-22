using Carvices.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carvices.DAL.Interfaces
{
    public interface ICarRepository
    {
        public Task<Guid> CreateAsync(Car car);
        public Task<ICollection<Car>> GetByOwnerIdAsync(Guid ownerId);
    }
}
