using System;

namespace Manager.Data.DTOs.StudentModule
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NewFullName { get; set; }
        public string StudentFullName => FirstName + " " + MiddleName + " " + LastName;
        public string DateOfBirth { get; set; }
        public Guid StreamId { get; set; }
        public Guid EmployeeId { get; set; }
        public string StreamName { get; set; }
        public string ClassName { get; set; }
        public Guid EntryClassId { get; set; }
        public Guid CurrentClassId { get; set; }
        public string ClassTeacher { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public Guid CountyId { get; set; }
        public string HomeTown { get; set; }
        public string IsBoarder { get; set; }
        public string Gender { get; set; }
        public int HostelCapacity { get; set; }
        public Guid? HostelId { get; set; }
        public int Age { get { return DateTime.Today.Year - Convert.ToDateTime(DateOfBirth).Year; } }
        public string BirthCertificateNumber { get; set; }
        public Guid ParentId { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentMiddleName { get; set; }
        public string ParentLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public int AdmNumber { get; set; }
    }
}
