﻿namespace Carvices.DAL.Entities
{
    public class ServiceAction
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public decimal? Price { get; set; }
        public decimal? HourEstimation { get; set; }
        public bool IsFree { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Service Service { get; set; }
        public ICollection<ServiceActionWorker> ServiceActionWorkers { get; set; }
    }
}
