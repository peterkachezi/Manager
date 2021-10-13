using Manager.Data.DTOs.DepartmentModule;
using Manager.Manager.Data.DepartmentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Administrator/Department
        private readonly IDepartmentService  departmentService;
        public DepartmentController(IDepartmentService  departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<ActionResult> Index()
        {
            var all = await departmentService.GetAllDepartment();

            var Department = all.Item2;

            return View(Department);
        }

        public async Task<ActionResult> CreatDepartment(DepartmentDTO  departmentDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                departmentDTO.CreatedById = user;

                var results = await departmentService.CreateDepartment(departmentDTO);

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


        public async Task<ActionResult> UpdateDepartment(DepartmentDTO  departmentDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                departmentDTO.UpdatedById = user;

                var results = await departmentService.UpdateDepartment(departmentDTO);

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

        public async Task<ActionResult> GetDepartmentById(string Id)
        {
            try
            {
                var data = await departmentService.GetDepartmentById(Id);

                if (data != null)
                {
                    DepartmentDTO file = new DepartmentDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreatedById = data.CreatedById,

                        CreateDate = data.CreateDate,
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