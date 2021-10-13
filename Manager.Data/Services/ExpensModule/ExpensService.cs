using Manager.Data.DTOs.ExpensModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExpensModule
{
    public class ExpensService : IExpensService
    {
        private readonly StudentEntities context;
        public ExpensService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(ExpensDTO expensDTO)
        {
            try
            {
                var s = new Expens
                {
                    Id = Guid.NewGuid(),

                    ExpenseTypeId = expensDTO.ExpenseTypeId,

                    ExpenseAmount = expensDTO.ExpenseAmount,

                    ExpenseDate = expensDTO.ExpenseDate,

                    Description = expensDTO.Description,

                    ReceiptAttachment = expensDTO.ReceiptAttachment,

                    CreateDate = DateTime.Now,

                    CreatedById = expensDTO.CreatedById,

                };

                context.Expenses.Add(s);

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

                var s = await context.Expenses.FindAsync(Id);

                if (s != null)
                {
                    context.Expenses.Remove(s);

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

        public async Task<List<ExpensDTO>> GetAll()
        {
            try
            {
                var expens = await context.Expenses.ToListAsync();

                var expenses = new List<ExpensDTO>();

                foreach (var item in expens)
                {
                    var data = new ExpensDTO
                    {
                        Id = item.Id,

                        ExpenseTypeId = item.ExpenseTypeId,

                        ExpenseAmount = item.ExpenseAmount,

                        ExpenseDate = item.ExpenseDate,

                        Description = item.Description,

                        ReceiptAttachment = item.ReceiptAttachment,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedName = item.AspNetUser.FirstName + " " + item.AspNetUser.FirstName,

                    };

                    expenses.Add(data);
                }
                return expenses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ExpensDTO> GetById(Guid Id)
        {
            try
            {
                var expens = await context.Expenses.FindAsync(Id);


                return new ExpensDTO
                {
                    Id = expens.Id,

                    ExpenseTypeId = expens.ExpenseTypeId,

                    ExpenseAmount = expens.ExpenseAmount,

                    ExpenseDate = expens.ExpenseDate,

                    Description = expens.Description,

                    ReceiptAttachment = expens.ReceiptAttachment,

                    CreateDate = expens.CreateDate,

                    CreatedById = expens.CreatedById,

                    CreatedName = expens.AspNetUser.FirstName + " " + expens.AspNetUser.FirstName,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(ExpensDTO expensDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Expenses.FindAsync(expensDTO.Id);
                    {

                        s.ExpenseTypeId = expensDTO.ExpenseTypeId;

                        s.ExpenseAmount = expensDTO.ExpenseAmount;

                        s.ExpenseDate = expensDTO.ExpenseDate;

                        s.Description = expensDTO.Description;

                        s.ReceiptAttachment = expensDTO.ReceiptAttachment;

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
