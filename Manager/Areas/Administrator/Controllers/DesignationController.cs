using Manager.Data.DesignationModule;
using Manager.Data.DTOs.DesignationModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService designationService;
        public DesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        public async Task<ActionResult> Index()
        {
            var all = await designationService.GetAllDesignation();

            var designation = all.Item2;

            return View(designation);
        }

        public async Task<ActionResult> CreatDesignation(DesignationDTO designationDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                designationDTO.CreatedById = user;

                var results = await designationService.CreateDesignation(designationDTO);

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


        public async Task<ActionResult> UpdateDesignation(DesignationDTO DesignationDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                DesignationDTO.UpdatedById = user;

                var results = await designationService.UpdateDesignation(DesignationDTO);

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

        public async Task<ActionResult> GetDesignationById(string Id)
        {
            try
            {
                var data = await designationService.GetDesignationById(Id);

                if (data != null)
                {
                    DesignationDTO file = new DesignationDTO()
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