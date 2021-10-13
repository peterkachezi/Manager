using Manager.Data.DTOs.SupplierModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.SupplierModule
{
    public class SupplierService : ISupplierService
    {
        private readonly StudentEntities context;
        public SupplierService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(SupplierDTO supplierDTO)
        {
            try
            {
                var s = new Supplier
                {
                    Id = Guid.NewGuid(),

                    Name = supplierDTO.Name,

                    Email = supplierDTO.Email,

                    PhoneNumber = supplierDTO.PhoneNumber,

                    CreateDate = DateTime.Now,

                    CreatedById = supplierDTO.CreatedById,

                };

                context.Suppliers.Add(s);

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

                var s = await context.Suppliers.FindAsync(Id);

                if (s != null)
                {
                    context.Suppliers.Remove(s);

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

        public async Task<List<SupplierDTO>> GetAll()
        {
            try
            {
                var supplier = await context.Suppliers.ToListAsync();

                var suppliers = new List<SupplierDTO>();

                foreach (var item in supplier)
                {
                    var data = new SupplierDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        Email = item.Email,

                        PhoneNumber = item.PhoneNumber,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName +" "+ item.AspNetUser.LastName,
                    };

                    suppliers.Add(data);
                }

                return suppliers;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<SupplierDTO> GetById(Guid Id)
        {
            try
            {
                var supplier = await context.Suppliers.FindAsync(Id);

                return new SupplierDTO
                {
                    Id = supplier.Id,

                    Name = supplier.Name,

                    Email = supplier.Email,

                    PhoneNumber = supplier.PhoneNumber,

                    CreateDate = supplier.CreateDate,

                    CreatedById = supplier.CreatedById,

                    CreatedByName = supplier.AspNetUser.FirstName +" "+ supplier.AspNetUser.LastName,
                };

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(SupplierDTO supplierDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Suppliers.FindAsync(supplierDTO.Id);
                    {

                        s.Name = supplierDTO.Name;

                        s.Email = supplierDTO.Email;

                        s.PhoneNumber = supplierDTO.PhoneNumber;

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
