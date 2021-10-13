using  Manager.Data.DTOs.StudentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.StudentModule
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(StudentDTO studentDTO);
        Task<StudentDTO> UpdateStudent(Guid Id,StudentDTO studentDTO);
        Task<bool> DeleteStudent(Guid Id);
        Task<List<StudentDTO>> GetAll();
        Task<StudentDTO> GetStudentById(Guid Id);
        Task<StudentDTO> GetAllByAdmNo(int AdmNo);
    }
}
