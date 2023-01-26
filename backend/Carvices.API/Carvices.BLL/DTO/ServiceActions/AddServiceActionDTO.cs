namespace Carvices.BLL.DTO.ServiceActions
{
    public class AddServiceActionDTO
    {
        public Guid ServiceId { get; set; }
        public decimal? Price { get; set; }
        public decimal? HourEstimation { get; set; }
        public bool IsFree { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
