using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.ClassModule
{
    public class ClassDTO
    {
        public Guid Id { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreateDate { get; set; }
                public string NewCreateDate { get { return CreateDate.ToShortDateString(); } }

        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid StreamId { get; set; }
        public string StreamName { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
