

using System;

namespace Manager.Data.DTOs.ExamResultsDTO
{
    
   
    
    public class MathDTO
    {
        public Guid Id { get; set; }
        public string Term { get; set; }
        public Guid StreamId { get; set; }
        public string StreamName { get; set; }
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public Guid StudentId { get; set; }
        public string Grade { get; set; }
        public double Points { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public double Marks { get; set; }
        public string StudentName { get; set; }
        public string Teacher { get; set; }
    }
}
