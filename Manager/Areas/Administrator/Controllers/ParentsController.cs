using Manager.Data.DTOs.ParentModule;
using Manager.Data.Services.ParentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ParentsController : Controller
    {
        // GET: Librarian/Authors
        private readonly IParentService  parentService;
        public ParentsController(IParentService parentService)
        {
            this.parentService = parentService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await parentService.GetAll();

            return View(suppliers);
        }

        //public async Task<ActionResult> Create(ParentDTO authorDTO)
        //{
        //    try
        //    {
        //        var user = User.Identity.GetUserId();

        //        authorDTO.CreatedById = user;

        //        var results = await authorService.Create(authorDTO);

        //        if (results == true)
        //        {
        //            return Json(new { success = true, responseText = "Author has been successfully registered", JsonRequestBehavior.AllowGet });

        //        }
        //        else
        //        {
        //            return Json(new { success = false, responseText = "Unable to save record", JsonRequestBehavior.AllowGet });

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);

        //        return null;
        //    }
        //}


        public async Task<ActionResult> Update(ParentDTO parentDTO)
        {
            try
            {


                var results = await parentService.Update(parentDTO);

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
                var data = await parentService.GetById(Id);

                if (data != null)
                {
                    ParentDTO file = new ParentDTO()
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

                        MiddleName = data.MiddleName,

                        LastName = data.LastName,

                        PhoneNumber = data.PhoneNumber,

                        IdNumber = data.IdNumber,

                        EmailAddress = data.EmailAddress,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,

                        StudentId = data.StudentId,
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