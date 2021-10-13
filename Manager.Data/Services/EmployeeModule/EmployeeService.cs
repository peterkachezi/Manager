using Manager.Data.DTOs.EmployeeModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Data.Services.EmployeeModule
{
    public class EmployeeService : IEmployeeService
    {
        private readonly StudentEntities context;
        public EmployeeService(StudentEntities context)
        {
            this.context = context;
        }

        public async Task<Tuple<bool, EmployeeDTO, string>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = new Employee
                {
                    Id = Guid.NewGuid(),

                    FirstName = employeeDTO.FirstName,

                    LastName = employeeDTO.LastName,

                    PhoneNumber = employeeDTO.PhoneNumber,

                    Email = employeeDTO.Email,

                    CreateDate = DateTime.Now,

                    CreatedById = employeeDTO.CreatedById,

                    UpdatedById = employeeDTO.CreatedById,

                    DepartmentId = employeeDTO.DepartmentId,

                    DesignationId = employeeDTO.DesignationId,

                };

                context.Employees.Add(employee);

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, EmployeeDTO, string>(res > 0, employeeDTO, res > 0 ? "Record has been successfully saved" : "Details could not be saved");

            }
            catch (Exception ex)
            {
                return new Tuple<bool, EmployeeDTO, string>(false, null, ex.Message);
            }
        }

        public async Task<bool> DeleteEmployee(string Id)
        {
            try
            {
                bool result = false;

                var s = await context.Employees.FindAsync(Id);

                if (s != null)
                {
                    context.Employees.Remove(s);

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

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var employee = await context.Employees.ToListAsync();

                var employees = new List<EmployeeDTO>();

                foreach (var item in employee)
                {
                    var data = new EmployeeDTO()
                    {
                        Id = item.Id,

                        FirstName = item.FirstName,

                        LastName = item.LastName,

                        PhoneNumber = item.PhoneNumber,

                        Email = item.Email,

                        CreateDate = DateTime.Now,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + " "+ item.AspNetUser.LastName,

                        UpdatedById = item.UpdatedById,

                        DepartmentId = item.DepartmentId,

                        DepartmentName = item.Department.Name,

                        DesignationId = item.DesignationId,

                        DesignationName = item.Designation.Name,
                    };

                    employees.Add(data);
                }

                return employees;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(string Id)
        {
            try
            {
                var employee = await context.Employees.FindAsync(Id);

                return new EmployeeDTO()
                {
                    Id = employee.Id,

                    FirstName = employee.FirstName,

                    LastName = employee.LastName,

                    PhoneNumber = employee.PhoneNumber,

                    Email = employee.Email,

                    CreateDate = employee.CreateDate,

                    CreatedById = employee.CreatedById,

                    UpdatedById = employee.UpdatedById,

                    DepartmentId = employee.DepartmentId,

                    DepartmentName = employee.Department.Name,

                    DesignationId = employee.DesignationId,

                    DesignationName = employee.Designation.Name,
                };



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<Tuple<bool, EmployeeDTO, string>> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Employees.FindAsync(employeeDTO.Id);
                    {
                        s.FirstName = employeeDTO.FirstName;

                        s.LastName = employeeDTO.LastName;

                        s.PhoneNumber = employeeDTO.PhoneNumber;

                        s.Email = employeeDTO.Email;

                        s.UpdatedById = employeeDTO.UpdatedById;

                        s.DepartmentId = employeeDTO.DepartmentId;

                        s.DesignationId = employeeDTO.DesignationId;

                    };

                    transaction.Commit();
                }

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, EmployeeDTO, string>(res > 0, employeeDTO, res > 0 ? "Record has been successfully saved" : "Details could not be saved");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
