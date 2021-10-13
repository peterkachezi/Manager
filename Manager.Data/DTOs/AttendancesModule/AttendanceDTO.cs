using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.AttendancesModule
{
  public  class AttendanceDTO
    {
        public System.Guid Id { get; set; }
        public System.DateTime AttendanceDate { get; set; }
        public System.Guid StudentId { get; set; }
        public string Remarks { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
