using Manager.Data.DTOs.ParentModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ParentModule
{
    public class ParentService : IParentService
    {
        private readonly StudentEntities context;
        public ParentService(StudentEntities context)
        {
            this.context = context;
        }
        public Task<bool> Create(ParentDTO parentDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Parents.FindAsync(Id);

                if (s != null)
                {
                    context.Parents.Remove(s);

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

        public async Task<List<ParentDTO>> GetAll()
        {
            try
            {
                var parent = await context.Parents.ToListAsync();

                var parents = new List<ParentDTO>();

                foreach (var item in parent)
                {
                    var data = new ParentDTO
                    {
                        Id = item.Id,

                        FirstName = item.FirstName,

                        MiddleName = item.MiddleName,

                        LastName = item.LastName,

                        PhoneNumber = item.PhoneNumber,

                        IdNumber = item.IdNumber,

                        EmailAddress = item.EmailAddress,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + "" + item.AspNetUser.LastName,

                        StudentId = item.StudentId,

                    };

                    parents.Add(data);
                }
                return parents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ParentDTO> GetById(Guid Id)
        {
            try
            {
                var parent = await context.Parents.FindAsync(Id);

                return new ParentDTO
                {
                    Id = parent.Id,

                    FirstName = parent.FirstName,

                    MiddleName = parent.MiddleName,

                    LastName = parent.LastName,

                    PhoneNumber = parent.PhoneNumber,

                    IdNumber = parent.IdNumber,

                    EmailAddress = parent.EmailAddress,

                    CreateDate = parent.CreateDate,

                    CreatedById = parent.CreatedById,

                    CreatedByName = parent.AspNetUser.FirstName + "" + parent.AspNetUser.LastName,

                    StudentId = parent.StudentId,

                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(ParentDTO parentDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var parent = await context.Parents.FindAsync(parentDTO.Id);
                    {

                        parent.FirstName = parentDTO.FirstName.Substring(0, 1).ToUpper() + parentDTO.FirstName.Substring(1).ToLower().Trim();

                        parent.MiddleName = parentDTO.MiddleName.Substring(0, 1).ToUpper() + parentDTO.MiddleName.Substring(1).ToLower().Trim();

                        parent.LastName = parentDTO.LastName.Substring(0, 1).ToUpper() + parentDTO.LastName.Substring(1).ToLower().Trim();

                        parent.PhoneNumber = parentDTO.PhoneNumber;

                        parent.IdNumber = parentDTO.IdNumber;

                        parent.EmailAddress = parentDTO.EmailAddress.Substring(1).ToLower();

                        parent.StudentId = parentDTO.Id;

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
