using Manager.Data.DTOs.CountyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.CountyModule
{
   public  interface ICountyService
    {
        Task<List<CountyDTO>> GetAllCounties();
        
    }
}
