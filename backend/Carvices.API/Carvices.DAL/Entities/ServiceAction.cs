namespace Carvices.DAL.Entities
{
    public class ServiceAction
    {
        public ServiceAction()
        {
            ServiceActionWorkers = new List<ServiceActionWorker>();
        }
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public decimal? Price { get; set; }
        public decimal? HourEstimation { get; set; }
        public bool IsFree { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public Service? Service { get; set; }
        public ICollection<ServiceActionWorker> ServiceActionWorkers { get; set; }
    }
}
