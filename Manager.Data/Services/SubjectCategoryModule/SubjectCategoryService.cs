using Manager.Data.DTOs.SubjectCategoryModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Manager.Data.Services.SubjectCategoryModule
{
    public class SubjectCategoryService : ISubjectCategoryService
    {
        private readonly StudentEntities context;

        public SubjectCategoryService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(SubjectCategoryDTO subjectCategoryDTO)
        {
            try
            {
                var s = new SubjectCategory
                {
                    Id = Guid.NewGuid(),

                    Name = subjectCategoryDTO.Name.Substring(0, 1).ToUpper() + subjectCategoryDTO.Name.Substring(1).ToLower().Trim(),

                    CreatedById = subjectCategoryDTO.CreatedById,

                    CreateDate = DateTime.Now,

                };

                context.SubjectCategories.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.SubjectCategories.FindAsync(Id);

                if (s != null)
                {
                    context.SubjectCategories.Remove(s);

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

        public async Task<List<SubjectCategoryDTO>> GetAll()
        {
            try
            {
                var combination = await context.SubjectCategories.ToListAsync();

                var combinations = new List<SubjectCategoryDTO>();

                foreach (var item in combination)
                {
                    var data = new SubjectCategoryDTO
                    {

                        Id = item.Id,

                        Name = item.Name,

                        CreatedById = item.CreatedById,

                        CreateDate = item.CreateDate,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,
                    };
                    combinations.Add(data);

                }

                return combinations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<SubjectCategoryDTO> GetById(Guid Id)
        {
            try
            {
                var combination = await context.SubjectCategories.FindAsync(Id);

                return new SubjectCategoryDTO
                {

                    Id = combination.Id,

                    Name = combination.Name,

                    CreatedById = combination.CreatedById,

                    CreateDate = combination.CreateDate,

                    CreatedByName = combination.AspNetUser.FirstName + " " + combination.AspNetUser.LastName,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(SubjectCategoryDTO subjectCategoryDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.SubjectCategories.FindAsync(subjectCategoryDTO.Id);
                    {
                        s.Name = subjectCategoryDTO.Name.Substring(0, 1).ToUpper() + subjectCategoryDTO.Name.Substring(1).ToLower().Trim();

                    };

                    transaction.Commit();

                    await context.SaveChangesAsync();
                }

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
