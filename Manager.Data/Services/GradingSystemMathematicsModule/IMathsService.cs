using Manager.Data.DTOs.GradingSystemMathematicsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemMathematicsModule
{
    public interface IMathsService
    {
        Task<List<MathDTO>> GetAll();
        Task<MathDTO> GetById(Guid Id);
        Task<bool> Create(MathDTO mathDTO);
        Task<bool> Update(MathDTO mathDTO);
        Task<bool> Delete(Guid Id);
    }
}
