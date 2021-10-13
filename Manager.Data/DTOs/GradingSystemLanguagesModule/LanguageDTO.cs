using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.GradingSystemLanguagesModule
{
    public class LanguageDTO
    {
        public System.Guid Id { get; set; }
        public double FromMarks { get; set; }
        public double ToMarks { get; set; }
        public string GradeName { get; set; }
        public double Points { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
