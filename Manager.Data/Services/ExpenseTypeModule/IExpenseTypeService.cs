using Manager.Data.DTOs.ExpenseTypeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExpenseTypeModule
{
    public interface IExpenseTypeService
    {
        Task<bool> Create(ExpenseTypeDTO expenseTypeDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(ExpenseTypeDTO expenseTypeDTO);
        Task<ExpenseTypeDTO> GetById(Guid Id);
        Task<List<ExpenseTypeDTO>> GetAll();
    }
}
