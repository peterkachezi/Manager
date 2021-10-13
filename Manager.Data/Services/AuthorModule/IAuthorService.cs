using Manager.Data.DTOs.AuthorModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AuthorModule
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAll();
        Task<AuthorDTO> GetById(Guid Id);
        Task<bool> Create(AuthorDTO authorDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(AuthorDTO authorDTO);

    }
}
