using Manager.Data.DTOs.HostelModule;
using Manager.Data.Services.HostelModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class HostelsController : Controller
    {
        private readonly IHostelService hostelService;
        public HostelsController(IHostelService hostelService)
        {
            this.hostelService = hostelService;
        }
        public async Task<ActionResult> Index()
        {
            var hostels = await hostelService.GetAllHostels();

            return View(hostels);
        }

        public async Task<ActionResult> Createhostel(HostelDTO  hostelDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                hostelDTO.CreatedById = user;

                var results = await hostelService.CreateHostel(hostelDTO);

                if (results ==true)
                {
                    return Json(new { success = true, responseText = "Hostel has been saved successfully", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> UpdateHostel(HostelDTO hostelDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                hostelDTO.UpdatedById = user;

                var results = await hostelService.UpdateHostel(hostelDTO);

                if (results ==true)
                {
                    return Json(new { success = true, responseText = "Hostel has been saved successfully" , JsonRequestBehavior.AllowGet });
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

        public async Task<ActionResult> GetHostelById(Guid Id)
        {
            try
            {
                var data = await hostelService.GetAllHostelById(Id);

                if (data != null)
                {
                    HostelDTO file = new HostelDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        Capacity = data.Capacity,

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