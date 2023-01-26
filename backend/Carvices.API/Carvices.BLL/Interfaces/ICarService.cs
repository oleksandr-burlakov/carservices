using Carvices.BLL.DTO.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carvices.BLL.Interfaces
{
    public interface ICarService
    {
        public Task<Guid> CreateAsync(CreateCarDTO createCar);
        public Task<ICollection<GetMyCarsDTO>> GetMyCarsAsync(Guid userId);
    }
}
