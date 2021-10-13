using Manager.Data.DesignationModule;
using Manager.Data.DTOs.EmployeeModule;
using Manager.Data.Services.EmployeeModule;
using Manager.Manager.Data.DepartmentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        private readonly IDepartmentService departmentService;

        private readonly IDesignationService designationService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IDesignationService designationService)
        {
            this.employeeService = employeeService;

            this.designationService = designationService;

            this.departmentService = departmentService;
        }

        public void StorePicture(string filename)
        {
            // Read the file into a byte array
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                byte[] imageData = new Byte[fs.Length];

                fs.Read(imageData, 0, (int)fs.Length);
            }

        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var employees = await employeeService.GetAllEmployees();

                ViewBag.departmentService = (await departmentService.GetAllDepartment()).Item2;

                ViewBag.designationService = (await designationService.GetAllDesignation()).Item2;

                return View(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> CreatEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                employeeDTO.CreatedById = user;

                var results = await employeeService.CreateEmployee(employeeDTO);

                if (results.Item1)
                {
                    return Json(new { success = true, responseText = results.Item3 }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to save record", JsonRequestBehavior.AllowGet });

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                employeeDTO.UpdatedById = user;

                var results = await employeeService.UpdateEmployee(employeeDTO);

                if (results.Item1)
                {
                    return Json(new { success = true, responseText = results.Item3 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to update record report details", JsonRequestBehavior.AllowGet });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> GetEmployeeById(string Id)
        {
            try
            {
                var data = await employeeService.GetEmployeeById(Id);

                if (data != null)
                {
                    EmployeeDTO file = new EmployeeDTO()
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

                        LastName = data.LastName,

                        PhoneNumber = data.PhoneNumber,

                        Email = data.Email,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        UpdatedById = data.UpdatedById,

                        DepartmentId = data.DepartmentId,

                        DepartmentName = data.DepartmentName,

                        DesignationId = data.DesignationId,

                        DesignationName = data.DesignationName,
                    };

                    return Json(new { data = file }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { data = false }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
    }
}