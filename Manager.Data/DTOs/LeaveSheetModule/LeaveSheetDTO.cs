using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.LeaveSheetModule
{
    public class LeaveSheetDTO
    {
        public System.Guid Id { get; set; }
        public System.Guid StudentId { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime DateTimeOut { get; set; }
        public System.DateTime DatetTimeIn { get; set; }
        public string Reasons { get; set; }
        public string AuthorisedById { get; set; }
        public byte RecordStatus { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
