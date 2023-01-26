using Microsoft.AspNetCore.Identity;

namespace Carvices.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid? JobId { get; set; }
        public decimal? PayRate { get; set; }
        public Service? Job { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<ServiceActionWorker> ServiceActionWorkers { get; set; } = new List<ServiceActionWorker>();
    }
}
