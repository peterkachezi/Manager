using Manager.Data.DTOs.GradingSystemHumanityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemHumanityModule
{
    public interface IHumanityService
    {
        Task<List<HumanityDTO>> GetAll();
        Task<HumanityDTO> GetById(Guid Id);
        Task<bool> Create(HumanityDTO  humanityDTO);
        Task<bool> Update(HumanityDTO humanityDTO);
        Task<bool> Delete(Guid Id);
    }
}
