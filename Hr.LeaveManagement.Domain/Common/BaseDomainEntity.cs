﻿namespace Hr.LeaveManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; } = "Flamur Dervishi";
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; } = "Flamur Dervishi";
    }
}
