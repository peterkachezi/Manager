using Manager.Data.DTOs.HumanityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.HumanityModule
{
   public interface IHumanityGradingService
    {
        Task<List<GradingHumanitiesDTO>> GetALLRecord();
        Task<GradingHumanitiesDTO> GetById(Guid Id);
        Task<bool> CreateRecord(GradingHumanitiesDTO gradingHumanitiesDTO);
        Task<bool> UpdateRecord(GradingHumanitiesDTO gradingHumanitiesDTO);
        Task<bool> DeleteRecord(Guid Id);
    }
}
