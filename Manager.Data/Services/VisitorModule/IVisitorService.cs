using Manager.Data.DTOs.VisitorModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.VisitorModule
{
   public  interface IVisitorService
    {
        Task<List<VisitorDTO>> GetAll();
        Task<VisitorDTO> GetById(Guid Id);
        Task<bool> Create(VisitorDTO visitorDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(VisitorDTO visitorDTO);
    }
}
