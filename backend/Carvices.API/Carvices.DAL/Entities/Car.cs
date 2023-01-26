﻿namespace Carvices.DAL.Entities
{
    public enum CarStatus
    {
        Broken = 0,
        InService = 1,
        Fixed = 2,
        Idle = 3
    }
    public class Car
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid OwnerId { get; set; }
        public CarStatus Status { get; set; }
        public User? Owner { get; set; }
    }
}
