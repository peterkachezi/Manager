using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.EmployeeModule
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedName { get; set; }
        public string DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
