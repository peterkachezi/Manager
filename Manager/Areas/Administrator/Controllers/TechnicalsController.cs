using Manager.Data.DTOs.GradingSystemTechnicalsModule;
using Manager.Data.Services.GradingSystemTechnicalsModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class TechnicalsController : Controller
    {
        private readonly ITechnicalService technicalService;
        public TechnicalsController(ITechnicalService technicalService)
        {
            this.technicalService = technicalService;

        }
        public async Task<ActionResult> Index()
        {
            var data = await technicalService.GetAll();

            return View(data);
        }

        public async Task<ActionResult> Create(TechnicalDTO technicalDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                technicalDTO.CreatedById = user;

                var results = await technicalService.Create(technicalDTO);

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

        public async Task<ActionResult> Update(TechnicalDTO technicalDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                var results = await technicalService.Update(technicalDTO);

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
                var data = await technicalService.GetById(Id);

                if (data != null)
                {
                    TechnicalDTO file = new TechnicalDTO()
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