using Manager.Data.DTOs.GradingSystemLanguagesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.GradingSystemLanguagesModule
{
    public interface ILanguagesService
    {
        Task<List<LanguageDTO>> GetAll();
        Task<LanguageDTO> GetById(Guid Id);
        Task<bool> Create(LanguageDTO languageDTO);
        Task<bool> Update(LanguageDTO languageDTO);
        Task<bool> Delete(Guid Id);
    }
}
