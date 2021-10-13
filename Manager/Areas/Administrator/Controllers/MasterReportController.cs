
using Manager.Data.StudentModule;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class MasterReportController : Controller
    {
        private readonly IStudentService studentService;
        public MasterReportController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}