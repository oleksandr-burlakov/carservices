namespace Carvices.DAL.Entities
{
    public class ServiceActionWorker
    {
        public Guid ServiceActionId { get; set; }
        public Guid WorkerId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ServiceAction? ServiceAction { get; set; }
        public User? Worker { get; set; }
    }
}
