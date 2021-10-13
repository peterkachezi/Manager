using Manager.Data.DTOs.ClassModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ClassModule
{
    public class ClassService : IClassService
    {
        private readonly StudentEntities context;
        public ClassService(StudentEntities context)
        {
            this.context = context;
        }

        public async Task<bool> Create(ClassDTO classDTO)
        {
            try
            {
                var s = new InstitutionClass
                {
                    Id = Guid.NewGuid(),

                    CreatedById = classDTO.CreatedById,

                    CreateDate = DateTime.Now,

                    EmployeeId = classDTO.EmployeeId,

                    StreamId = classDTO.StreamId,

                    Name = classDTO.Name,

                };

                context.InstitutionClasses.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.InstitutionClasses.FindAsync(Id);

                if (s != null)
                {
                    context.InstitutionClasses.Remove(s);

                    await context.SaveChangesAsync();

                    return true;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<List<ClassDTO>> GetAll()
        {
            try
            {
                var s = await context.InstitutionClasses.ToListAsync();

                var classes = new List<ClassDTO>();

                foreach (var item in s)
                {
                    var data = new ClassDTO
                    {
                        Id = item.Id,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        CreateDate = item.CreateDate,

                        EmployeeId = item.EmployeeId,

                        EmployeeName = item.Employee.FirstName + " " + item.Employee.LastName,

                        StreamId = item.StreamId,

                        StreamName = item.Stream.Name,

                        Name = item.Name,

                    };

                    classes.Add(data);
                }

                return classes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ClassDTO> GetById(Guid Id)
        {
            try
            {
                var s = await context.InstitutionClasses.FindAsync(Id);

                return new ClassDTO
                {
                    Id = s.Id,

                    CreatedById = s.CreatedById,

                    CreatedByName = s.AspNetUser.FirstName + " " + s.AspNetUser.LastName,

                    CreateDate = s.CreateDate,

                    EmployeeId = s.EmployeeId,

                    EmployeeName = s.Employee.FirstName + " " + s.Employee.LastName,

                    StreamId = s.StreamId,

                    StreamName = s.Stream.Name,

                    Name = s.Name,

                };

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(ClassDTO classDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.InstitutionClasses.FindAsync(classDTO.Id);
                    {

                        s.EmployeeId = classDTO.EmployeeId;

                        s.StreamId = classDTO.StreamId;

                        s.Name = classDTO.Name;

                    };

                    transaction.Commit();

                    await context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
