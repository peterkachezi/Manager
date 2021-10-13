using Manager.Data.DTOs.AttendancesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AttendancesModule
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDTO>> GetAll();
        Task<AttendanceDTO> GetById(Guid Id);
        Task<bool> Create(AttendanceDTO attendanceDTO);
        Task<bool> Update(AttendanceDTO attendanceDTO);
        Task<bool> Delete(Guid Id);
    }
}
