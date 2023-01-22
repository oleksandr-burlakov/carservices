namespace Carvices.DAL.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
        public ICollection<User> Workers { get; set; }
        public ICollection<ServiceWorkDays> ServiceWorkDays { get; set; }
        public ICollection<ServiceAction> ServiceActions { get; set; }
    }
}
