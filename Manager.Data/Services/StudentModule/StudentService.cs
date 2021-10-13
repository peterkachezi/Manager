using Manager.Data.DTOs.StudentModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Manager.Data.EDMX;
using System.Linq;

namespace Manager.Data.StudentModule
{
    public class StudentService : IStudentService
    {
        private readonly StudentEntities context;
        public StudentService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                studentDTO.Id = Guid.NewGuid();

                var student = new Student
                {
                    Id = studentDTO.Id,
                                      

                    FirstName = studentDTO.FirstName.Substring(0, 1).ToUpper() + studentDTO.FirstName.Substring(1).ToLower().Trim(),

                    MiddleName = studentDTO.MiddleName.Substring(0, 1).ToUpper() + studentDTO.MiddleName.Substring(1).ToLower().Trim(),

                    LastName = studentDTO.LastName.Substring(0, 1).ToUpper() + studentDTO.LastName.Substring(1).ToLower().Trim(),

                    DateOfBirth = studentDTO.DateOfBirth,

                    StreamId = studentDTO.StreamId,

                    EntryClassId = studentDTO.EntryClassId,

                    CurrentClassId = studentDTO.EntryClassId,

                    JoiningDate = studentDTO.JoiningDate,

                    CreateDate = DateTime.Now,

                    CreatedById = studentDTO.CreatedById,

                    UpdatedById = studentDTO.CreatedById,

                    HomeTown = studentDTO.HomeTown.Substring(0, 1).ToUpper() + studentDTO.HomeTown.Substring(1).ToLower().Trim(),

                    Gender = studentDTO.Gender,

                    BirthCertificateNumber = studentDTO.BirthCertificateNumber,

                    AdmNumber = studentDTO.AdmNumber,

                };

                context.Students.Add(student);

                var parent = new Parent
                {
                    Id = Guid.NewGuid(),

                    FirstName = studentDTO.ParentFirstName.Substring(0, 1).ToUpper() + studentDTO.ParentFirstName.Substring(1).ToLower().Trim(),

                    MiddleName = studentDTO.ParentMiddleName.Substring(0, 1).ToUpper() + studentDTO.ParentMiddleName.Substring(1).ToLower().Trim(),

                    LastName = studentDTO.ParentLastName.Substring(0, 1).ToUpper() + studentDTO.ParentLastName.Substring(1).ToLower().Trim(),

                    PhoneNumber = studentDTO.PhoneNumber,

                    IdNumber = studentDTO.IdNumber,

                    EmailAddress = studentDTO.EmailAddress.Substring(1).ToLower(),

                    CreateDate = DateTime.Now,

                    CreatedById = studentDTO.CreatedById,

                    StudentId = studentDTO.Id,

                    CountyId = studentDTO.CountyId,

                };

                context.Parents.Add(parent);

                if (studentDTO.IsBoarder == "1")
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var hostel = await context.Hostels.FindAsync(studentDTO.HostelId);

                        hostel.Capacity = studentDTO.HostelCapacity - 1;

                        transaction.Commit();
                    };

                }

                return await context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteStudent(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Students.FindAsync(Id);

                if (s != null)
                {
                    context.Students.Remove(s);

                    await context.SaveChangesAsync();

                    return true;
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            try
            {
                var student = await context.Students.ToListAsync();

                var students = new List<StudentDTO>();

                foreach (var item in student)
                {
                    var data = new StudentDTO
                    {
                        Id = item.Id,

                        FirstName = item.FirstName,

                        MiddleName = item.MiddleName,

                        LastName = item.LastName,

                        AdmNumber = item.AdmNumber,

                        Gender = item.Gender,

                        DateOfBirth = item.DateOfBirth,

                        StreamId = item.StreamId,

                        StreamName = item.Stream.Name,

                        ClassName = item.InstitutionClass.Name,

                        CurrentClassId = item.CurrentClassId,

                        EntryClassId = item.EntryClassId,

                        ClassTeacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                        EmployeeId = item.InstitutionClass.EmployeeId,

                        JoiningDate = item.JoiningDate,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        BirthCertificateNumber = item.BirthCertificateNumber,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                    };

                    students.Add(data);
                }
                return students;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<StudentDTO> GetAllByAdmNo(int AdmNo)
        {
            try
            {
                var all = await context.Students.ToListAsync();

                var student = all.Where(x=>x.AdmNumber==AdmNo).FirstOrDefault();

                if (student == null)
                {
                    return null;
                }

                return new StudentDTO
                {
                    Id = student.Id,

                    FirstName = student.FirstName,

                    MiddleName = student.MiddleName,

                    LastName = student.LastName,

                    AdmNumber = student.AdmNumber,

                    DateOfBirth = student.DateOfBirth,
                      
                    StreamId = student.StreamId,

                    EntryClassId = student.EntryClassId,

                    CurrentClassId = student.CurrentClassId,

                    JoiningDate = student.JoiningDate,

                    CreateDate = student.CreateDate,

                    CreatedById = student.CreatedById,

                    CreatedByName = student.AspNetUser.FirstName + " " + student.AspNetUser.LastName,

                    StreamName = student.Stream.Name,

                    ClassName = student.InstitutionClass.Name,

                    ClassTeacher = student.InstitutionClass.Employee.FirstName + " " + student.InstitutionClass.Employee.LastName,

                    Gender = student.Gender,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<StudentDTO> GetStudentById(Guid Id)
        {
            try
            {
                var student = await context.Students.FindAsync(Id);

                return new StudentDTO
                {
                    Id = student.Id,

                    FirstName = student.FirstName,

                    MiddleName = student.MiddleName,

                    LastName = student.LastName,

                    AdmNumber = student.AdmNumber,

                    DateOfBirth = student.DateOfBirth,

                    StreamId = student.StreamId,

                    EntryClassId = student.EntryClassId,

                    CurrentClassId = student.CurrentClassId,

                    JoiningDate = student.JoiningDate,

                    CreateDate = student.CreateDate,

                    CreatedById = student.CreatedById,

                    CreatedByName = student.AspNetUser.FirstName + " " + student.AspNetUser.LastName,

                    StreamName = student.Stream.Name,

                    ClassName = student.InstitutionClass.Name,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<StudentDTO> UpdateStudent(Guid Id, StudentDTO studentDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Students.FindAsync(Id);
                    {
                        s.FirstName = studentDTO.FirstName;

                        s.MiddleName = studentDTO.MiddleName;

                        s.LastName = studentDTO.LastName;

                        s.DateOfBirth = studentDTO.DateOfBirth;

                        s.StreamId = studentDTO.StreamId;

                        s.CurrentClassId = studentDTO.CurrentClassId;

                        s.JoiningDate = studentDTO.JoiningDate;

                    };

                    transaction.Commit();
                }

                await context.SaveChangesAsync();

                return studentDTO;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
