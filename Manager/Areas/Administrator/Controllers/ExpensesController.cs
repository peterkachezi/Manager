using Manager.Data.DTOs.ExpensModule;
using Manager.Data.Services.ExpensModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensService expensService;
        public ExpensesController(IExpensService expensService)
        {
            this.expensService = expensService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await expensService.GetAll();

            return View(suppliers);
        }

        public async Task<ActionResult> Create(ExpensDTO expenseDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                expenseDTO.CreatedById = user;

                var results = await expensService.Create(expenseDTO);

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


        public async Task<ActionResult> Update(ExpensDTO expensDTO)
        {
            try
            {
                var results = await expensService.Update(expensDTO);

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
                var data = await expensService.GetById(Id);

                if (data != null)
                {
                    ExpensDTO file = new ExpensDTO()
                    {
                        Id = data.Id,

                        ExpenseTypeId = data.ExpenseTypeId,

                        ExpenseAmount = data.ExpenseAmount,

                        ExpenseDate = data.ExpenseDate,

                        Description = data.Description,

                        ReceiptAttachment = data.ReceiptAttachment,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        CreatedName = data.CreatedName,
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