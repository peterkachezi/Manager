using Manager.Data.DTOs.InstituitonModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.InstituitonModule
{
    public class InstituitonService : IInstituitonService
    {
        private readonly StudentEntities context;
        public InstituitonService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(InstituitonDTO instituitonDTO)
        {
            try
            {
                var s = new Instituiton
                {
                    Id = Guid.NewGuid(),

                    Name = instituitonDTO.Name,

                    Email = instituitonDTO.Email,

                    PhoneNumber = instituitonDTO.PhoneNumber,

                    PostalAddrress = instituitonDTO.PostalAddrress,

                    PostalCode = instituitonDTO.PostalCode,

                    CreateDate = DateTime.Now,

                    CreatedById = instituitonDTO.CreatedById,

                    Town = instituitonDTO.Town,

                    Image = instituitonDTO.Image1,

                };

                context.Instituitons.Add(s);

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

                var s = await context.Instituitons.FindAsync(Id);

                if (s != null)
                {
                    context.Instituitons.Remove(s);

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
        public async Task<InstituitonDTO> GetById(Guid Id)
        {
            var s = await context.Instituitons.FindAsync(Id);

            return new InstituitonDTO
            {
                Id = s.Id,

                Name = s.Name,

                Email = s.Email,

                PhoneNumber = s.PhoneNumber,

                PostalAddrress = s.PostalAddrress,

                PostalCode = s.PostalCode,

                CreateDate = s.CreateDate,

                CreatedById = s.CreatedById,

                Town = s.Town,

                CreatedByName = s.AspNetUser.FirstName + " " + s.AspNetUser.LastName,
            };
        }

        public async Task<bool> Update(InstituitonDTO instituitonDTO)
        {
            try
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Instituitons.FindAsync(instituitonDTO.Id);
                    {

                        s.Name = instituitonDTO.Name;

                        s.Email = instituitonDTO.Email;

                        s.PhoneNumber = instituitonDTO.PhoneNumber;

                        s.PostalAddrress = instituitonDTO.PostalAddrress;

                        s.PostalCode = instituitonDTO.PostalCode;

                        s.Town = instituitonDTO.Town;

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
