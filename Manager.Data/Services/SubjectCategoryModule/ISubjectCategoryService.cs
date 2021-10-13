using Manager.Data.DTOs.SubjectCategoryModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.SubjectCategoryModule
{
    public interface ISubjectCategoryService
    {
        Task<List<SubjectCategoryDTO>> GetAll();
        Task<SubjectCategoryDTO> GetById(Guid Id);
        Task<bool> Create(SubjectCategoryDTO  subjectCategoryDTO);
        Task<bool> Update(SubjectCategoryDTO subjectCategoryDTO);
        Task<bool> Delete(Guid Id);
    }
}
