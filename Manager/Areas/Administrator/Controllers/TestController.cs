using Manager.Data.EDMX;
using Manager.Data.Services.ExaminationModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class TestController : Controller
    {
        private readonly IExaminationService examinationService;


        public TestController(IExaminationService examinationService)
        {
            this.examinationService = examinationService;
           
        }
        public async Task<ActionResult> Index(int Number)
        {
            var data = await examinationService.Test();

            //var query = db.Tests.SqlQuery("select * from Test where 38 between FromNo and ToNo").ToList();

            var lhouses = data.Where(s => s.FromNo.CompareTo(Number) <= 0 && s.ToNo.CompareTo(Number) >= 0).FirstOrDefault();


            return View();



        }
    }
}