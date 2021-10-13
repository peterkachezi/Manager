using Manager.Data.DTOs.GradingSystemMathematicsModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemMathematicsModule
{
    public class MathsService : IMathsService
    {
        private readonly StudentEntities context;
        public MathsService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(MathDTO mathDTO)
        {
            try
            {
                var s = new GradingMathematic
                {
                    Id = Guid.NewGuid(),

                    FromMarks = mathDTO.FromMarks,

                    ToMarks = mathDTO.ToMarks,

                    GradeName = mathDTO.GradeName,

                    CreatedById = mathDTO.CreatedById,

                    CreateDate = DateTime.Now,

                };

                context.GradingMathematics.Add(s);

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

                var s = await context.GradingMathematics.FindAsync(Id);

                if (s != null)
                {
                    context.GradingMathematics.Remove(s);

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

        public async Task<List<MathDTO>> GetAll()
        {
            try
            {
                var humanity = await context.GradingMathematics.ToListAsync();

                var humanities = new List<MathDTO>();

                foreach (var item in humanity)
                {
                    var data = new MathDTO
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

        public async Task<MathDTO> GetById(Guid Id)
        {
            try
            {
                var humanity = await context.GradingMathematics.FindAsync(Id);

                return new MathDTO
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

        public async Task<bool> Update(MathDTO mathDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingMathematics.FindAsync(mathDTO.Id);
                    {

                        s.FromMarks = mathDTO.FromMarks;

                        s.ToMarks = mathDTO.ToMarks;

                        s.GradeName = mathDTO.GradeName;

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
