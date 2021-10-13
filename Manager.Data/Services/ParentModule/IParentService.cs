using Manager.Data.DTOs.ParentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ParentModule
{
    public interface IParentService
    {
        Task<List<ParentDTO>> GetAll();
        Task<ParentDTO> GetById(Guid Id);
        Task<bool> Create(ParentDTO parentDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(ParentDTO parentDTO);
    }
}
