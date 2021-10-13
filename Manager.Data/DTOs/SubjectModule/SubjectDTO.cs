using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.SubjectModule
{
    public class SubjectDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedById { get; set; }
        public Guid SubjectCategoryId { get; set; }
        public string SubjectCategoryName { get; set; }
    }
}
