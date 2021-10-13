using Manager.Data.DTOs.GradingSystemHumanityModule;
using Manager.Data.Services.GradingSystemHumanityModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class HumanitiesController : Controller
    {
        private readonly IHumanityService humanityService;
        public HumanitiesController(IHumanityService humanityService)
        {
            this.humanityService = humanityService;

        }
        public async Task<ActionResult> Index()
        {
            var data = await humanityService.GetAll();


            return View(data);
        }

        public async Task<ActionResult> Create(HumanityDTO humanityDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                humanityDTO.CreatedById = user;

                var results = await humanityService.Create(humanityDTO);

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

        public async Task<ActionResult> Update(HumanityDTO humanityDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                var results = await humanityService.Update(humanityDTO);

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
                var data = await humanityService.GetById(Id);

                if (data != null)
                {
                    HumanityDTO file = new HumanityDTO()
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