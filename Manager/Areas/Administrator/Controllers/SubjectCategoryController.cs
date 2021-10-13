using Manager.Data.DTOs.SubjectCategoryModule;
using Manager.Data.Services.SubjectCategoryModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class SubjectCategoryController : Controller
    {
        private readonly ISubjectCategoryService subjectCombinationService;
        public SubjectCategoryController(ISubjectCategoryService subjectCombinationService)
        {
            this.subjectCombinationService = subjectCombinationService;
        }
        public async Task<ActionResult> Index()
        {
            var combination = await subjectCombinationService.GetAll();

            return View(combination);
        }

        public async Task<ActionResult> Create(SubjectCategoryDTO subjectCategoryDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                subjectCategoryDTO.CreatedById = user;

                var results = await subjectCombinationService.Create(subjectCategoryDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been saved successfully", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(SubjectCategoryDTO subjectCategoryDTO)
        {
            try
            {

                var results = await subjectCombinationService.Update(subjectCategoryDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = " Record been updated successfully", JsonRequestBehavior.AllowGet });
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
                var data = await subjectCombinationService.GetById(Id);

                if (data != null)
                {
                    SubjectCategoryDTO file = new SubjectCategoryDTO()
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

        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                var results = await subjectCombinationService.Delete(Id);

                if (results == true)
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