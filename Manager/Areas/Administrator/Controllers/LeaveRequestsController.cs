using Manager.Data.DTOs.LeaveSheetModule;
using Manager.Data.Services.LeaveSheetModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveSheetService leaveSheetService;
        public LeaveRequestsController(ILeaveSheetService leaveSheetService)
        {
            this.leaveSheetService = leaveSheetService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await leaveSheetService.GetAll();

            return View(suppliers);
        }

        public async Task<ActionResult> Create(LeaveSheetDTO leaveSheetDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                leaveSheetDTO.CreatedById = user;

                var results = await leaveSheetService.Create(leaveSheetDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Request  has been successfully submitted", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(LeaveSheetDTO leaveSheetDTO)
        {
            try
            {


                var results = await leaveSheetService.Update(leaveSheetDTO);

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
                var data = await leaveSheetService.GetById(Id);

                if (data != null)
                {
                    LeaveSheetDTO file = new LeaveSheetDTO()
                    {
                        Id = data.Id,

                        StudentId = data.StudentId,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,

                        DateTimeOut = data.DateTimeOut,

                        DatetTimeIn = data.DatetTimeIn,

                        Reasons = data.Reasons,

                        AuthorisedById = data.AuthorisedById,

                        RecordStatus = data.RecordStatus,

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