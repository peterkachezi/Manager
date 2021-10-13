using Manager.Data.DTOs.SubjectModule;
using Manager.Data.Services.SubjectCategoryModule;
using Manager.Data.Services.SubjectModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService  subjectService;
        private readonly ISubjectCategoryService  subjectCategoryService;

        public SubjectsController(ISubjectService  subjectService, ISubjectCategoryService subjectCategoryService)
        {
            this.subjectService = subjectService;
            this.subjectCategoryService = subjectCategoryService;
        }
        public async Task<ActionResult> Index()
        {
            var subjects = await subjectService.GetAllSubject();

            ViewBag.SubjectCategory = await subjectCategoryService.GetAll();

            return View(subjects);
        }

        public async Task<ActionResult> CreateSubject(SubjectDTO  subjectDTO)
        {
            try
            {
                var subjectname = subjectDTO.Name.Substring(0, 1).ToUpper() + subjectDTO.Name.Substring(1).ToLower().Trim();

                var getsubject = (await subjectService.GetAllSubject()).Where(x => x.Name == subjectname).FirstOrDefault();

                if (getsubject != null)
                {
                    return Json(new { success = false, responseText = "The subject already exists", JsonRequestBehavior.AllowGet });

                }

                var user = User.Identity.GetUserId();

                subjectDTO.CreatedById = user;


                var results = await subjectService.AddSubject(subjectDTO);

                if (results==true)
                {
                    return Json(new { success = true, responseText = "Record has been saved successfuly", JsonRequestBehavior.AllowGet });

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

        public async Task<ActionResult> UpdateSubject(SubjectDTO  subjectDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                subjectDTO.UpdatedById = user;

                var results = await subjectService.UpdateSubject(subjectDTO);

                if (results ==true)
                {
                    return Json(new { success = true, responseText = "Record has been updated successfully", JsonRequestBehavior.AllowGet });
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

        public async Task<ActionResult> GetSubjectById(Guid Id)
        {
            try
            {
                var data = await subjectService.GetSubjectById(Id);

                if (data != null)
                {
                    SubjectDTO file = new SubjectDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreatedById = data.CreatedById,

                        CreateDate = data.CreateDate,

                        CreatedByName = data.CreatedByName,

                        SubjectCategoryId = data.SubjectCategoryId,
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

        public async Task<ActionResult> DeleteSubject(Guid Id)
        {
            try
            {
                var results = await subjectService.DeleteSubject(Id);

                if (results==true)
                {
                    return Json(new { success = true, responseText = "Record  has been  successfully Deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Failed to Delete because the file is in use with other records!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        
    }
}