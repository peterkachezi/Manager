using Manager.Data.DTOs.GradingSystemTechnicalsModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemTechnicalsModule
{
    public class TechnicalService : ITechnicalService
    {
        private readonly StudentEntities context;
        public TechnicalService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(TechnicalDTO  technicalDTO)
        {
            try
            {
                var s = new GradingTechnical
                {
                    Id = Guid.NewGuid(),

                    FromMarks = technicalDTO.FromMarks,

                    ToMarks = technicalDTO.ToMarks,

                    GradeName = technicalDTO.GradeName,

                    Points = technicalDTO.Points,

                    CreatedById = technicalDTO.CreatedById,

                    CreateDate = DateTime.Now,

                };

                context.GradingTechnicals.Add(s);

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

                var s = await context.GradingTechnicals.FindAsync(Id);

                if (s != null)
                {
                    context.GradingTechnicals.Remove(s);

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

        public async Task<List<TechnicalDTO>> GetAll()
        {
            try
            {
                var humanity = await context.GradingTechnicals.ToListAsync();

                var humanities = new List<TechnicalDTO>();

                foreach (var item in humanity)
                {
                    var data = new TechnicalDTO
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

        public async Task<TechnicalDTO> GetById(Guid Id)
        {
            try
            {
                var humanity = await context.GradingTechnicals.FindAsync(Id);

                return new TechnicalDTO
                {
                    Id = humanity.Id,

                    FromMarks = humanity.FromMarks,

                    ToMarks = humanity.ToMarks,

                    GradeName = humanity.GradeName,

                    Points = humanity.Points,

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

        public async Task<bool> Update(TechnicalDTO technicalDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingTechnicals.FindAsync(technicalDTO.Id);
                    {

                        s.FromMarks = technicalDTO.FromMarks;

                        s.ToMarks = technicalDTO.ToMarks;

                        s.GradeName = technicalDTO.GradeName;

                        s.Points = technicalDTO.Points;


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
