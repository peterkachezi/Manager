using Manager.Data.DTOs.GradingSystemHumanityModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemHumanityModule
{
    public class HumanityService : IHumanityService
    {
        private readonly StudentEntities context;
        public HumanityService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(HumanityDTO humanityDTO)
        {
            try
            {
                var s = new GradingHumanity
                {
                    Id = Guid.NewGuid(),

                    FromMarks = humanityDTO.FromMarks,

                    ToMarks = humanityDTO.ToMarks,

                    GradeName = humanityDTO.GradeName,

                    CreatedById = humanityDTO.CreatedById,

                    Points = humanityDTO.Points,

                    CreateDate = DateTime.Now,

                };

                context.GradingHumanities.Add(s);

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

                var s = await context.GradingHumanities.FindAsync(Id);

                if (s != null)
                {
                    context.GradingHumanities.Remove(s);

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

        public async Task<List<HumanityDTO>> GetAll()
        {
            try
            {
                var humanity = await context.GradingHumanities.ToListAsync();

                var humanities = new List<HumanityDTO>();

                foreach (var item in humanity)
                {
                    var data = new HumanityDTO
                    {
                        Id = item.Id,

                        FromMarks = item.FromMarks,

                        ToMarks = item.ToMarks,

                        GradeName = item.GradeName,

                        CreatedById = item.CreatedById,

                        CreateDate = item.CreateDate,

                        Points = item.Points,
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

        public async Task<HumanityDTO> GetById(Guid Id)
        {
            try
            {
                var humanity = await context.GradingHumanities.FindAsync(Id);

                return new HumanityDTO
                {
                    Id = humanity.Id,

                    FromMarks = humanity.FromMarks,

                    ToMarks = humanity.ToMarks,

                    GradeName = humanity.GradeName,

                    CreatedById = humanity.CreatedById,

                    CreateDate = humanity.CreateDate,

                    Points = humanity.Points,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(HumanityDTO humanityDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingHumanities.FindAsync(humanityDTO.Id);
                    {

                        s.FromMarks = humanityDTO.FromMarks;

                        s.ToMarks = humanityDTO.ToMarks;

                        s.GradeName = humanityDTO.GradeName;

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
