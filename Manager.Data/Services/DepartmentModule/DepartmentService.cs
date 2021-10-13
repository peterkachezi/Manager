using  Manager.Data.DTOs.DepartmentModule;
using Manager.Data.EDMX;
using Manager.Manager.Data.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace Manager.Data.DepartmentModule
{
    public class DepartmentService : IDepartmentService
    {
        private readonly StudentEntities context;

        public DepartmentService(StudentEntities context)
        {
            this.context = context;
        }


        public async Task<Tuple<bool, DepartmentDTO, string>> CreateDepartment(DepartmentDTO  departmentDTO)
        {
            try
            {
                var s = new Department
                {
                    Id = Guid.NewGuid().ToString(),

                    Name = departmentDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedById = departmentDTO.CreatedById,

                          };

                context.Departments.Add(s);

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, DepartmentDTO, string>(res > 0 ? true : false, departmentDTO, res > 0 ? "Record has been successfully saved" : "Details could not be saved");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }



        public async Task<bool> DeleteDepartment(string Id)
        {
            try
            {
                bool result = false;

                var s = await context.Departments.FindAsync(Id);

                if (s != null)
                {
                    context.Departments.Remove(s);

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


        public async Task<Tuple<bool, List<DepartmentDTO>, string>> GetAllDepartment()
        {
            try
            {
                var claim = (from d in context.Departments

                             join u in context.AspNetUsers on d.CreatedById equals u.Id

                             select new DepartmentDTO()
                             {
                                 Id = d.Id,

                                 Name = d.Name,

                                 CreateDate = d.CreateDate,

                                 CreatedById = d.CreatedById,

                                 CreatedByName = u.FirstName + " " + u.LastName,

                             }).ToListAsync();

                return new Tuple<bool, List<DepartmentDTO>, string>(true, await claim, "claim details");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }

        public async Task<DepartmentDTO> GetDepartmentById(string Id)
        {
            try
            {
                var department = await context.Departments.FindAsync(Id);

                return new DepartmentDTO
                {
                    Id = department.Id,

                    Name = department.Name,

                    CreateDate = department.CreateDate,

                    CreatedById = department.CreatedById,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<Tuple<bool, DepartmentDTO, string>> UpdateDepartment(DepartmentDTO  departmentDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Departments.FindAsync(departmentDTO.Id);
                    {
                        s.Name = departmentDTO.Name;

                    };

                    transaction.Commit();
                }

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, DepartmentDTO, string>(res > 0, departmentDTO, res > 0 ? "Record  has been successfully updated" : "Details could not update");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new Tuple<bool, DepartmentDTO, string>(false, null, ex.Message);
            }
        }

    }
}
