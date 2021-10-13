using Manager.Data.DTOs.ClassModule;
using Manager.Data.Services.ClassModule;
using Manager.Data.Services.EmployeeModule;
using Manager.Data.StreamModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassService classService;

        private readonly IStreamService streamService;

        private readonly IEmployeeService employeeService;
        public ClassesController(IClassService classService, IStreamService streamService, IEmployeeService employeeService)
        {
            this.classService = classService;

            this.streamService = streamService;

            this.employeeService = employeeService;
        }
        public async Task<ActionResult> Index()
        {
            var getallclasses = (await classService.GetAll()).OrderBy(x => x.Name);

            ViewBag.Teacher = (await employeeService.GetAllEmployees()).Where(x => x.DesignationName == "Teacher");

            ViewBag.Stream = await streamService.GetAllStream();

            return View(getallclasses);
        }

        public async Task<ActionResult> Create(ClassDTO classDTO)
        {
            try
            {
                var validateteacher = (await classService.GetAll()).Where(x => x.EmployeeId == classDTO.EmployeeId).Count();

                if (validateteacher != 0)
                {
                    return Json(new { success = false, responseText = "The teacher has been assign another class", JsonRequestBehavior.AllowGet });

                }

                var validateclass = (await classService.GetAll()).Where(x => x.StreamId == classDTO.StreamId && x.Name == classDTO.Name).Count();

                if (validateclass != 0)
                {
                    return Json(new { success = false, responseText = "The class has already been registered", JsonRequestBehavior.AllowGet });

                }

                var user = User.Identity.GetUserId();

                classDTO.CreatedById = user;

                var results = await classService.Create(classDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been saved successfully", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(ClassDTO classDTO)
        {
            try
            {



                var results = await classService.Update(classDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = " Record been updated successfully", JsonRequestBehavior.AllowGet });
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

        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await classService.GetById(Id);

                if (data != null)
                {
                    ClassDTO file = new ClassDTO()
                    {
                        Id = data.Id,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,

                        CreateDate = data.CreateDate,

                        EmployeeId = data.EmployeeId,

                        EmployeeName = data.EmployeeName,

                        StreamId = data.StreamId,

                        StreamName = data.StreamName,

                        Name = data.Name,
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

        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                var results = await classService.Delete(Id);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record  has been  successfully Deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Failed to Delete because the file is in use with other records!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}