namespace Carvices.DAL.Entities
{
    public enum DayNumber
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }
    public class ServiceWorkDays
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public DayNumber DayNumber { get; set; }
        public int? FromHour { get; set; }
        public int? ToHour { get; set; }
        public Service? Service { get; set; }
    }
}
