using Manager.Data.DTOs.HostelModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.HostelModule
{
   public interface IHostelService
    {
        Task<List<HostelDTO>> GetAllHostels();
        Task<HostelDTO> GetAllHostelById(Guid Id);
        Task<bool> CreateHostel(HostelDTO hostelDTO);
        Task<bool> UpdateHostel(HostelDTO hostelDTO);
        Task<bool> DeleteHostel(Guid Id);

    }
}
