using Manager.Data.DTOs.GradingSystemTechnicalsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemTechnicalsModule
{
    public interface ITechnicalService
    {
        Task<List<TechnicalDTO>> GetAll();
        Task<TechnicalDTO> GetById(Guid Id);
        Task<bool> Create(TechnicalDTO  technicalDTO);
        Task<bool> Update(TechnicalDTO  technicalDTO);
        Task<bool> Delete(Guid Id);
    }
}
