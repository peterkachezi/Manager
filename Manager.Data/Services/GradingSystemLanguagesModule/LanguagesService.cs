using Manager.Data.DTOs.GradingSystemLanguagesModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemLanguagesModule
{
    public class LanguagesService : ILanguagesService
    {
        private readonly StudentEntities context;
        public LanguagesService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(LanguageDTO languageDTO)
        {
            try
            {
                var s = new GradingLanguage
                {
                    Id = Guid.NewGuid(),

                    FromMarks = languageDTO.FromMarks,

                    ToMarks = languageDTO.ToMarks,

                    GradeName = languageDTO.GradeName,

                    CreatedById = languageDTO.CreatedById,

                    CreateDate = DateTime.Now,

                };

                context.GradingLanguages.Add(s);

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

                var s = await context.GradingLanguages.FindAsync(Id);

                if (s != null)
                {
                    context.GradingLanguages.Remove(s);

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

        public async Task<List<LanguageDTO>> GetAll()
        {
            try
            {
                var humanity = await context.GradingLanguages.ToListAsync();

                var humanities = new List<LanguageDTO>();

                foreach (var item in humanity)
                {
                    var data = new LanguageDTO
                    {
                        Id = item.Id,

                        FromMarks = item.FromMarks,

                        ToMarks = item.ToMarks,

                        GradeName = item.GradeName,

                        Points = item.Points,

                        CreatedById = item.CreatedById,

                        CreateDate = item.CreateDate,
                    };

                    humanities.Add(data);
                }
                return humanities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<LanguageDTO> GetById(Guid Id)
        {
            try
            {
                var humanity = await context.GradingLanguages.FindAsync(Id);

                return new LanguageDTO
                {
                    Id = humanity.Id,

                    FromMarks = humanity.FromMarks,

                    ToMarks = humanity.ToMarks,

                    GradeName = humanity.GradeName,

                    CreatedById = humanity.CreatedById,

                    CreateDate = humanity.CreateDate,
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(LanguageDTO languageDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingLanguages.FindAsync(languageDTO.Id);
                    {

                        s.FromMarks = languageDTO.FromMarks;

                        s.ToMarks = languageDTO.ToMarks;

                        s.GradeName = languageDTO.GradeName;

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
