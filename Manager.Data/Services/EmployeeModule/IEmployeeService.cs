using Manager.Data.DTOs.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.EmployeeModule
{
   public interface IEmployeeService
    {
        Task<Tuple<bool, EmployeeDTO, string>> UpdateEmployee(EmployeeDTO EmployeeDTO);
        Task<bool> DeleteEmployee(string Id);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeById(string Id);
        Task<Tuple<bool, EmployeeDTO, string>> CreateEmployee(EmployeeDTO EmployeeDTO);
    }
}
