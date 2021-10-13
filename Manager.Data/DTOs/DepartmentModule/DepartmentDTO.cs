using System;

namespace Manager.Data.DTOs.DepartmentModule
{
    public  class DepartmentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string CreatedByName { get; set; }
    }
}
