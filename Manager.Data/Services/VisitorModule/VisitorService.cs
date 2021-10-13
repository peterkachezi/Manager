using Manager.Data.DTOs.VisitorModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.VisitorModule
{
    public class VisitorService : IVisitorService
    {
        private readonly StudentEntities context;

        public VisitorService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(VisitorDTO visitorDTO)
        {
            try
            {
                var s = new Visitor
                {
                    Id = Guid.NewGuid(),

                    Name = visitorDTO.Name,

                    PhoneNumber = visitorDTO.PhoneNumber,

                    Email = visitorDTO.Email,

                    CreatedById = visitorDTO.CreatedById,

                    CreateDate = DateTime.Now,

                    Remarks = visitorDTO.Remarks,

                    IsParent = visitorDTO.IsParent,

                };
                context.Visitors.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;

            }
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VisitorDTO>> GetAll()
        {
            try
            {
                var visitor = await context.Visitors.ToListAsync();

                var visitors = new List<VisitorDTO>();

                foreach (var item in visitor)
                {
                    var data = new VisitorDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        PhoneNumber = item.PhoneNumber,

                        Email = item.Email,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + "" + item.AspNetUser.LastName,

                        CreateDate = item.CreateDate,

                        Remarks = item.Remarks,

                        IsParent = item.IsParent,

                    };

                    visitors.Add(data);
                }
                return visitors;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<VisitorDTO> GetById(Guid Id)
        {
            try
            {
                var visitor = await context.Visitors.FindAsync(Id);

                return new VisitorDTO
                {
                    Id = visitor.Id,

                    Name = visitor.Name,

                    PhoneNumber = visitor.PhoneNumber,

                    Email = visitor.Email,

                    CreatedById = visitor.CreatedById,

                    CreatedByName = visitor.AspNetUser.FirstName + "" + visitor.AspNetUser.LastName,

                    CreateDate = visitor.CreateDate,

                    Remarks = visitor.Remarks,

                    IsParent = visitor.IsParent,
                };
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(VisitorDTO visitorDTO)
        {
            try
            {
                using (var transactions = context.Database.BeginTransaction())
                {
                    var s = await context.Visitors.FindAsync(visitorDTO.Id);
                    {
                        s.Name = visitorDTO.Name;

                        s.PhoneNumber = visitorDTO.PhoneNumber;

                        s.Email = visitorDTO.Email;

                        s.Remarks = visitorDTO.Remarks;

                        s.IsParent = visitorDTO.IsParent;

                    };

                    transactions.Commit();

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
