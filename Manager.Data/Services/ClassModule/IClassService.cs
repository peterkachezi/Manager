using Manager.Data.DTOs.ClassModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ClassModule
{
    public interface IClassService
    {
        Task<List<ClassDTO>> GetAll();
        Task<ClassDTO> GetById(Guid Id);
        Task<bool> Create(ClassDTO classDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(ClassDTO classDTO);
    }
}
