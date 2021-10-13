using Manager.Data.DTOs.AdmissionNumberModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmissionNumberModule
{
    public class AdmissionNumberService : IAdmissionNumberService
    {
        private readonly StudentEntities context;

        public AdmissionNumberService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(AdmissionNumberDTO admissionNumberDTO)
        {
            try
            {
                var s = new AdmissionNumber
                {
                    Id = Guid.NewGuid(),

                    Number = admissionNumberDTO.Number,

                    CreateDate = DateTime.Now,

                    CreatedById = admissionNumberDTO.CreatedById,

                };

                context.AdmissionNumbers.Add(s);

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
                bool results = false;

                var s = await context.AdmissionNumbers.FindAsync(Id);

                if (s != null)
                {
                    context.AdmissionNumbers.Remove(s);

                    await context.SaveChangesAsync();

                    return true;
                }
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public Task<List<AdmissionNumberDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AdmissionNumberDTO> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(AdmissionNumberDTO admissionNumberDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.AdmissionNumbers.FindAsync(admissionNumberDTO.Id);
                    {
                        s.Number = admissionNumberDTO.Number;

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
