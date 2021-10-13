using Manager.Data.DTOs.SupplierModule;
using Manager.Data.Services.SupplierModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Administrator/Suppliers
        private readonly ISupplierService supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = await supplierService.GetAll();

            return View(suppliers);
        }

        public async Task<ActionResult> Create(SupplierDTO  supplierDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                supplierDTO.CreatedById = user;

                var results = await supplierService.Create(supplierDTO);

                if (results ==true)
                {
                    return Json(new { success = true, responseText = "Supplier has been successfully registered", JsonRequestBehavior.AllowGet });

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


        public async Task<ActionResult> Update(SupplierDTO SupplierDTO)
        {
            try
            {
             

                var results = await supplierService.Update(SupplierDTO);

                if (results ==true)
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
                var data = await supplierService.GetById(Id);

                if (data != null)
                {
                    SupplierDTO file = new SupplierDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        Email = data.Email,

                        PhoneNumber = data.PhoneNumber,

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