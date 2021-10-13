using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.ExaminationModule
{
    public class ExaminationDTO
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public double Music { get; set; }
        public double Biology { get; set; }
        public double Chemistry { get; set; }
        public double Physics { get; set; }
        public double Agriculture { get; set; }
        public double ComputerStudies { get; set; }
        public double BussinessManagement { get; set; }
        public double Kiswahili { get; set; }
        public double CRE { get; set; }
        public double ArtDesign { get; set; }
        public double HomeScience { get; set; }
        public double BuildingConstruction { get; set; }
        public double French { get; set; }
        public double German { get; set; }
        public double Geography { get; set; }
        public double English { get; set; }
        public double Mathematics { get; set; }
        public double HistoryGovernment { get; set; }


        public System.DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedById { get; set; }
        public string CreatedById { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string StreamName { get; set; }
        public Guid StreamId { get; set; }
        public Guid ClassId { get; set; }
        public double Points { get; set; }
        public string Grade { get; set; }

    }
}
