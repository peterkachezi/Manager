using Manager.Data.DTOs.BookModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.BookModule
{
    public interface IBookService
    {
        Task<bool> Create(BookDTO bookDTO);
        Task<bool> Delete(BookDTO bookDTO);
        Task<bool> Update(BookDTO bookDTO);
        Task<BookDTO> GetById(Guid Id);
        Task<List<BookDTO>> GetAll();
    }
}
