using Manager.Data.DTOs.HumanityModule;
using Manager.Data.EDMX;
using Manager.Data.Services.HumanityModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemModule
{
    public class HumanityGradingService : IHumanityGradingService
    {
        private readonly StudentEntities context;

        public HumanityGradingService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> CreateRecord(GradingHumanitiesDTO gradingHumanitiesDTO)
        {
            try
            {
                var s = new GradingHumanity
                {
                    Id = Guid.NewGuid(),

                    FromMarks = gradingHumanitiesDTO.FromMarks,

                    ToMarks = gradingHumanitiesDTO.ToMarks,

                    GradeName = gradingHumanitiesDTO.GradeName,

                    CreatedById = gradingHumanitiesDTO.CreatedById,

                    UpdatedById = gradingHumanitiesDTO.CreatedById,

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

        public async Task<bool> DeleteRecord(Guid Id)
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

        public async Task<List<GradingHumanitiesDTO>> GetALLRecord()
        {
            try
            {
                var record = await context.GradingHumanities.ToListAsync();

                var records = new List<GradingHumanitiesDTO>();

                foreach (var item in record)
                {
                    var data = new GradingHumanitiesDTO()
                    {
                        Id = item.Id,

                        FromMarks = item.FromMarks,

                        ToMarks = item.ToMarks,

                        GradeName = item.GradeName,

                        CreatedById = item.CreatedById,

                        UpdatedById = item.CreatedById,

                        CreateDate = item.CreateDate,
                    };

                    records.Add(data);
                }

                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<GradingHumanitiesDTO> GetById(Guid Id)
        {
            try
            {
                var record = await context.GradingHumanities.FindAsync(Id);

                return new GradingHumanitiesDTO()
                {
                    Id = record.Id,


                    FromMarks = record.FromMarks,

                    ToMarks = record.ToMarks,

                    GradeName = record.GradeName,

                    CreatedById = record.CreatedById,

                    UpdatedById = record.CreatedById,

                    CreateDate = record.CreateDate,
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> UpdateRecord(GradingHumanitiesDTO gradingHumanitiesDTO)
        {
            try
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.GradingHumanities.FindAsync(gradingHumanitiesDTO.Id);
                    {
                        s.FromMarks = gradingHumanitiesDTO.FromMarks;

                        s.ToMarks = gradingHumanitiesDTO.ToMarks;

                        s.GradeName = gradingHumanitiesDTO.GradeName;

                        s.UpdatedById = gradingHumanitiesDTO.UpdatedById;

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
