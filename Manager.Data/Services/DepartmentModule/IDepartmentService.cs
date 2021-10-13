using Manager.Data.DTOs.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Manager.Data.DepartmentModule
{
    public interface IDepartmentService
    {
        Task<Tuple<bool, DepartmentDTO, string>> CreateDepartment(DepartmentDTO departmentDTO);
        Task<Tuple<bool, DepartmentDTO, string>> UpdateDepartment(DepartmentDTO departmentDTO);
        Task<bool>DeleteDepartment(string Id);
        Task<DepartmentDTO> GetDepartmentById(string Id);
        Task<Tuple<bool, List<DepartmentDTO>, string>> GetAllDepartment();
    }
}
