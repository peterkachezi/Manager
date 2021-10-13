using System;

namespace Manager.Data.DTOs.SubjectCategoryModule
{
    public class SubjectCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
