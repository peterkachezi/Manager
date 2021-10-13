using Manager.Data.DTOs.ExpensModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExpensModule
{
    public interface IExpensService
    {
        Task<ExpensDTO> GetById(Guid Id);
        Task<List<ExpensDTO>> GetAll();
        Task<bool> Create(ExpensDTO  expensDTO);
        Task<bool> Update(ExpensDTO  expensDTO);
        Task<bool> Delete(Guid Id);
    }
}
