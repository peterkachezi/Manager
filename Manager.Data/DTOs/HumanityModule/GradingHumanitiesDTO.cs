using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.HumanityModule
{
    public class GradingHumanitiesDTO
    {
        public System.Guid Id { get; set; }
        public string SubjectId { get; set; }
        public double FromMarks { get; set; }
        public double ToMarks { get; set; }
        public string GradeName { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
