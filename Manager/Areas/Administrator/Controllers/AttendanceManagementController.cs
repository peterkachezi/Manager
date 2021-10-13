using Manager.Data.DTOs.AttendancesModule;
using Manager.Data.Services.AttendancesModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class AttendanceManagementController : Controller
    {
        private readonly IAttendanceService  attendanceService;
        public AttendanceManagementController(IAttendanceService  attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await attendanceService.GetAll();

            return View(suppliers);
        }

        public async Task<ActionResult> Create(AttendanceDTO attendanceDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                attendanceDTO.CreatedById = user;

                var results = await attendanceService.Create(attendanceDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Attendance has been successfully submitted", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(AttendanceDTO attendanceDTO)
        {
            try
            {

                var results = await attendanceService.Update(attendanceDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been successfully updated", JsonRequestBehavior.AllowGet });
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
                var data = await attendanceService.GetById(Id);

                if (data != null)
                {
                    AttendanceDTO file = new AttendanceDTO()
                    {
                        Id = data.Id,

                        AttendanceDate = data.AttendanceDate,

                        StudentId = data.StudentId,

                        Remarks = data.Remarks,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,

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