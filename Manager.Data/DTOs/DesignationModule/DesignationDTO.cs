using System;

namespace Manager.Data.DTOs.DesignationModule
{
    public class DesignationDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedById { get; set; }
    }
}
