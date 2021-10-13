using Manager.Data.DTOs.StreamModule;
using Manager.Data.Services.EmployeeModule;
using Manager.Data.StreamModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class StreamsController : Controller
    {

        private readonly IStreamService streamService;

        private readonly IEmployeeService employeeService;

        public StreamsController(IStreamService streamService, IEmployeeService employeeService)
        {
            this.streamService = streamService;

            this.employeeService = employeeService;
        }
        public async Task<ActionResult> Index()
        {
            var streams = await streamService.GetAllStream();

            ViewBag.Employee = await employeeService.GetAllEmployees();

            return View(streams);
        }

        public async Task<ActionResult> Create(StreamDTO streamDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                streamDTO.CreatedById = user;

                var results = await streamService.CreateStream(streamDTO);


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

        public async Task<ActionResult> Update(StreamDTO streamDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                streamDTO.CreatedById =user;

                var results = await streamService.UpdateStream(streamDTO);

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

        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await streamService.GetstreamById(Id);

                if (data != null)
                {
                    StreamDTO file = new StreamDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreatedById = data.CreatedById,

                        EmployeeId = data.EmployeeId,

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