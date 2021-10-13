using Manager.Data.DTOs.ExpenseTypeModule;
using Manager.Data.Services.ExpenseTypeModule;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ExpenseTypesController : Controller
    {
        private readonly IExpenseTypeService  expenseTypeService;
        public ExpenseTypesController(IExpenseTypeService  expenseTypeService)
        {
            this.expenseTypeService = expenseTypeService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await expenseTypeService.GetAll();

            return View(suppliers);
        }

        public async Task<ActionResult> Create(ExpenseTypeDTO  expenseTypeDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                expenseTypeDTO.CreatedById = user;

                var results = await expenseTypeService.Create(expenseTypeDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been successfully submitted", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(ExpenseTypeDTO expenseTypeDTO)
        {
            try
            {
                var results = await expenseTypeService.Update(expenseTypeDTO);

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
                var data = await expenseTypeService.GetById(Id);

                if (data != null)
                {
                    ExpenseTypeDTO file = new ExpenseTypeDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,
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