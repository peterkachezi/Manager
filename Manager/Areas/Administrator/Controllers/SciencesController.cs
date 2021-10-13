using Manager.Data.DTOs.GradingSystemSciencesModule;
using Manager.Data.Services.GradingSystemSciencesModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class SciencesController : Controller
    {
        private readonly ISciencesService  sciencesService;
        public SciencesController(ISciencesService sciencesService)
        {
            this.sciencesService = sciencesService;

        }
        public async Task<ActionResult> Index()
        {
            var data = await sciencesService.GetAll();

            return View(data);
        }

        public async Task<ActionResult> Create(ScienceDTO  scienceDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                scienceDTO.CreatedById = user;

                var results = await sciencesService.Create(scienceDTO);

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

        public async Task<ActionResult> Update(ScienceDTO scienceDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                var results = await sciencesService.Update(scienceDTO);

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
                var data = await sciencesService.GetById(Id);

                if (data != null)
                {
                    ScienceDTO file = new ScienceDTO()
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