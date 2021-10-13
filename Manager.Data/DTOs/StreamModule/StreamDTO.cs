using System;

namespace Manager.Data.DTOs.StreamModule
{
    public class StreamDTO
    {
        public Guid Id { get; set; }
        public Guid UpdatedById { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
