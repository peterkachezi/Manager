using Manager.Data.DTOs.FurnitureModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.FurnitureModule
{
  public  interface IFurnitureService
    {
        Task<List<FurnitureDTO>> GetAll();
        Task<FurnitureDTO> GetById(Guid Id);
        Task<bool> Create(FurnitureDTO furnitureDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(FurnitureDTO furnitureDTO);
    }
}
