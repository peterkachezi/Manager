using Manager.Data.DTOs.AdmissionNumberModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmissionNumberModule
{
   public interface IAdmissionNumberService
    {
        Task<List<AdmissionNumberDTO>> GetAll();
        Task<AdmissionNumberDTO> GetById(Guid Id);
        Task<bool> Create(AdmissionNumberDTO admissionNumberDTO);
        Task<bool> Update(AdmissionNumberDTO admissionNumberDTO);
        Task<bool> Delete(Guid Id);
    }
}
