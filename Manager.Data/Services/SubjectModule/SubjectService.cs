using Manager.Data.DTOs.SubjectModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.SubjectModule
{
    public class SubjectService : ISubjectService
    {
        private readonly StudentEntities context;

        public SubjectService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> AddSubject(SubjectDTO subjectDTO)
        {
            try
            {
                var s = new Subject
                {
                    Id = Guid.NewGuid(),

                    Name = subjectDTO.Name.Trim(),

                    CreateDate = DateTime.Now,

                    CreatedById = subjectDTO.CreatedById,

                    UpdatedById = subjectDTO.CreatedById,

                    SubjectCategoryId = subjectDTO.SubjectCategoryId,
                };

                context.Subjects.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteSubject(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Subjects.FindAsync(Id);

                if (s != null)
                {
                    context.Subjects.Remove(s);

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

        public async Task<List<SubjectDTO>> GetAllSubject()
        {
            try
            {
                var subject = await context.Subjects.ToListAsync();

                var subjects = new List<SubjectDTO>();

                foreach (var item in subject)
                {
                    var data = new SubjectDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        SubjectCategoryId = item.SubjectCategoryId,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        SubjectCategoryName = item.SubjectCategory.Name,
                    };

                    subjects.Add(data);
                }

                return subjects;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<SubjectDTO> GetSubjectById(Guid Id)
        {
            try
            {
                var subject = await context.Subjects.FindAsync(Id);

                return new SubjectDTO
                {
                    Id = subject.Id,

                    Name = subject.Name,

                    CreateDate = subject.CreateDate,

                    CreatedById = subject.CreatedById,

                    CreatedByName = subject.AspNetUser.FirstName + " " + subject.AspNetUser.LastName,

                    SubjectCategoryName = subject.SubjectCategory.Name,

                    SubjectCategoryId = subject.SubjectCategoryId,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }



        public async Task<bool> UpdateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Subjects.FindAsync(subjectDTO.Id);
                    {
                        s.Name = subjectDTO.Name.Trim();

                        s.UpdatedById = subjectDTO.UpdatedById;

                        s.SubjectCategoryId = subjectDTO.SubjectCategoryId;
                    };

                    transaction.Commit();
                }
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
