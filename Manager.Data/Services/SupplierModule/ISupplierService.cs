using Manager.Data.DTOs.SupplierModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.SupplierModule
{
   public  interface ISupplierService
    {
        Task<List<SupplierDTO>> GetAll();
        Task<SupplierDTO> GetById(Guid Id);
        Task<bool> Create(SupplierDTO supplierDTO);
        Task<bool> Update(SupplierDTO supplierDTO);
        Task<bool> Delete(Guid Id);
    }
}
