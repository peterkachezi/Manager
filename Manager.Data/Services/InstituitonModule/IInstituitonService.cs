using Manager.Data.DTOs.InstituitonModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.InstituitonModule
{
    public interface IInstituitonService 
    {
        Task<bool> Create(InstituitonDTO instituitonDTO);
        Task<bool> Update(InstituitonDTO instituitonDTO);
        Task<bool> Delete(Guid Id);
        Task<InstituitonDTO> GetById(Guid Id);

    }
}
