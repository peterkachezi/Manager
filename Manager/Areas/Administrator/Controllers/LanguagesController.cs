using Manager.Data.DTOs.GradingSystemLanguagesModule;
using Manager.Data.Services.GradingSystemLanguagesModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguagesService  languagesService;
        public LanguagesController(ILanguagesService languagesService)
        {
            this.languagesService = languagesService;

        }
        public async Task<ActionResult> Index()
        {
            var data = await languagesService.GetAll();


            return View(data);
        }

        public async Task<ActionResult> Create(LanguageDTO  languageDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                languageDTO.CreatedById = user;

                var results = await languagesService.Create(languageDTO);

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

        public async Task<ActionResult> Update(LanguageDTO languageDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                var results = await languagesService.Update(languageDTO);

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
                var data = await languagesService.GetById(Id);

                if (data != null)
                {
                    LanguageDTO file = new LanguageDTO()
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