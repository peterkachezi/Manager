using  Manager.Data.DTOs.DesignationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DesignationModule
{
 public   interface IDesignationService
    {
        Task<Tuple<bool, DesignationDTO, string>> CreateDesignation(DesignationDTO designationDTO);
        Task<Tuple<bool, DesignationDTO, string>> UpdateDesignation(DesignationDTO designationDTO);
        Task<bool> DeleteDesignation(string Id);
        Task<DesignationDTO> GetDesignationById(string Id);
        Task<Tuple<bool, List<DesignationDTO>, string>> GetAllDesignation();
    }
}
