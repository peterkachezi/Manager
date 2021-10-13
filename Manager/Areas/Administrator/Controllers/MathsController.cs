using Manager.Data.DTOs.GradingSystemMathematicsModule;
using Manager.Data.Services.GradingSystemMathematicsModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class MathsController : Controller
    {
        private readonly IMathsService  mathsService;
        public MathsController(IMathsService mathsService)
        {
            this.mathsService = mathsService;

        }
        public async Task<ActionResult> Index()
        {
            var data = await mathsService.GetAll();

            return View(data);
        }

        public async Task<ActionResult> Create(MathDTO  mathDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                mathDTO.CreatedById = user;

                var results = await mathsService.Create(mathDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been saved successfully", }, JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> Update(MathDTO mathDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                var results = await mathsService.Update(mathDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been updated successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to update record  details", JsonRequestBehavior.AllowGet });
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
                var data = await mathsService.GetById(Id);

                if (data != null)
                {
                    MathDTO file = new MathDTO()
                    {
                        Id = data.Id,

                        FromMarks = data.FromMarks,

                        ToMarks = data.ToMarks,

                        GradeName = data.GradeName,

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