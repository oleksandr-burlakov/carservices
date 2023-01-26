using Carvices.DAL.Entities;
using Carvices.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carvices.DAL.Realization
{
    public class ServiceActionRepository : IServiceActionRepository
    {
        private readonly EFContext _context;
        public ServiceActionRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddAsync(ServiceAction serviceAction)
        {
            var returnServiceAction = await _context.ServiceActions.AddAsync(serviceAction);
            await _context.SaveChangesAsync();
            return returnServiceAction.Entity.Id;
        }

        public async Task<ICollection<ServiceAction>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _context.ServiceActions
                .Where(sa => sa.ServiceId == serviceId)
                .ToListAsync();
        }
    }
}
