using Manager.Data.DTOs.SubjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.SubjectModule
{
    public interface ISubjectService
    {
        Task<List<SubjectDTO>> GetAllSubject();
        Task<SubjectDTO> GetSubjectById(Guid Id);
        Task<bool> DeleteSubject(Guid Id);
        Task<bool> UpdateSubject(SubjectDTO subjectDTO);
        Task<bool> AddSubject(SubjectDTO subjectDTO);
    }
}
