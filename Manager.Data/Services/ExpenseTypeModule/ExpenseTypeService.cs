using Manager.Data.DTOs.ExpenseTypeModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExpenseTypeModule
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly StudentEntities context;
        public ExpenseTypeService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(ExpenseTypeDTO expenseTypeDTO)
        {
            try
            {
                var s = new ExpenseType
                {
                    Id = Guid.NewGuid(),

                    Name = expenseTypeDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedById = expenseTypeDTO.CreatedById,

                };

                context.ExpenseTypes.Add(s);

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

                var s = await context.ExpenseTypes.FindAsync(Id);

                if (s != null)
                {
                    context.ExpenseTypes.Remove(s);

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

        public async Task<List<ExpenseTypeDTO>> GetAll()
        {
            try
            {
                var expensetype = await context.ExpenseTypes.ToListAsync();

                var expensetypes = new List<ExpenseTypeDTO>();

                foreach (var item in expensetype)
                {
                    var data = new ExpenseTypeDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                    };

                    expensetypes.Add(data);
                }
                return expensetypes;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return null;
            }
        }



        public async Task<ExpenseTypeDTO> GetById(Guid Id)
        {
            try
            {
                var expensetype = await context.ExpenseTypes.FindAsync(Id);

                return new ExpenseTypeDTO
                {
                    Id = expensetype.Id,

                    Name = expensetype.Name,

                    CreateDate = expensetype.CreateDate,

                    CreatedById = expensetype.CreatedById,

                    CreatedByName = expensetype.AspNetUser.FirstName + " " + expensetype.AspNetUser.LastName,

                };

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(ExpenseTypeDTO expenseTypeDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.ExpenseTypes.FindAsync(expenseTypeDTO.Id);
                    {
                        s.Name = expenseTypeDTO.Name;
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
