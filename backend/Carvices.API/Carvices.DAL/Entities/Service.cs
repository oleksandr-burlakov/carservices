namespace Carvices.DAL.Entities
{
    public class Service
    {
        public Service()
        {
            Workers = new List<User>();
            ServiceWorkDays = new List<ServiceWorkDays>();
            ServiceActions = new List<ServiceAction>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
        public ICollection<User> Workers { get; set; }
        public ICollection<ServiceWorkDays> ServiceWorkDays { get; set; }
        public ICollection<ServiceAction> ServiceActions { get; set; }
    }
}
