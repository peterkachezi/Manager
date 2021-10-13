using Manager.Data.DTOs.GradingSystemSciencesModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemSciencesModule
{
    public class SciencesService : ISciencesService
    {
        private readonly StudentEntities context;
        public SciencesService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(ScienceDTO scienceDTO)
        {
            try
            {
                var s = new GradingScience
                {
                    Id = Guid.NewGuid(),

                    FromMarks = scienceDTO.FromMarks,

                    ToMarks = scienceDTO.ToMarks,

                    GradeName = scienceDTO.GradeName,

                    CreatedById = scienceDTO.CreatedById,

                    UpdatedById = scienceDTO.CreatedById,

                    Points = scienceDTO.Points,

                    CreateDate = DateTime.Now,

                };

                context.GradingSciences.Add(s);

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

                var s = await context.GradingSciences.FindAsync(Id);

                if (s != null)
                {
                    context.GradingSciences.Remove(s);

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

        public async Task<List<ScienceDTO>> GetAll()
        {
            try
            {
                var science = (await context.GradingSciences.ToListAsync()).OrderByDescending(x=>x.Points);

                var sciences = new List<ScienceDTO>();

                foreach (var item in science)
                {
                    var data = new ScienceDTO
                    {
                        Id = item.Id,

                        FromMarks = item.FromMarks,

                        ToMarks = item.ToMarks,

                        GradeName = item.GradeName,

                        Points = item.Points,

                        CreatedById = item.CreatedById,

                        CreateDate = item.CreateDate,
                    };

                    sciences.Add(data);
                }
                return sciences;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ScienceDTO> GetById(Guid Id)
        {
            try
            {
                var humanity = await context.GradingSciences.FindAsync(Id);

                return new ScienceDTO
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

        public async Task<bool> Update(ScienceDTO scienceDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingSciences.FindAsync(scienceDTO.Id);
                    {

                        s.FromMarks = scienceDTO.FromMarks;

                        s.ToMarks = scienceDTO.ToMarks;

                        s.GradeName = scienceDTO.GradeName;

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
