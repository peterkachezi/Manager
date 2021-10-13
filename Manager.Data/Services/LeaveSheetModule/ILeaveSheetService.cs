using Manager.Data.DTOs.LeaveSheetModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.LeaveSheetModule
{
    public interface ILeaveSheetService
    {
        Task<bool> Create(LeaveSheetDTO leaveSheetDTO);
        Task<bool> Update(LeaveSheetDTO leaveSheetDTO);
        Task<bool> Delete(Guid Id);
        Task<LeaveSheetDTO> GetById(Guid Id);
        Task<List<LeaveSheetDTO>> GetAll();
    }
}
