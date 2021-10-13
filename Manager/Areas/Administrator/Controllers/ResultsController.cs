using Manager.Data.Services.ResultsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ResultsController : Controller
    {

        private readonly IExamResultService examResultService;

        public ResultsController(IExamResultService examResultService)
        {

         this.examResultService=examResultService;

        }

        public async Task<ActionResult> IndexAsync()
        {

            var agrics = await examResultService.GetAllAgricultureResults();

            return View();
        }
    }
}