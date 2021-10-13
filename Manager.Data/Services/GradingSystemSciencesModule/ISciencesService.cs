using Manager.Data.DTOs.GradingSystemSciencesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemSciencesModule
{
   public  interface ISciencesService
    {
        Task<List<ScienceDTO>> GetAll();
        Task<ScienceDTO> GetById(Guid Id);
        Task<bool> Create(ScienceDTO  scienceDTO);
        Task<bool> Update(ScienceDTO scienceDTO);
        Task<bool> Delete(Guid Id);
    }
}
