using Manager.Data.EDMX;
using Manager.Data.Services.ClassModule;
using Manager.Data.StudentModule;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class StudentReportsController : Controller
    {
        private readonly IStudentService studentService;

        private readonly IClassService classService;
        public StudentReportsController(IStudentService studentService, IClassService classService)
        {
            this.studentService = studentService;

            this.classService = classService;
        }
        public ActionResult Index(DateTime Year)
        {
            return View();
        }

        public async Task<ActionResult> GetAllStudentsAsync()
        {
            try
            {
                var all = await classService.GetAll();

                string sDate = DateTime.Now.ToString();

                string sDay = DateTime.Parse(sDate).Day.ToString();

                string sMonth = DateTime.Parse(sDate).Month.ToString();

                string sYear = DateTime.Parse(sDate).Year.ToString();

                var data = all.Where(a => a.CreateDate.Year == long.Parse(sYear)).ToList();

                return View();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;

            }

        }

        public async Task<ActionResult> GenerateAllStudentDumpFileReport()
        {
            var appointment = await studentService.GetAll();

            var builder = new StringBuilder();

            builder.AppendLine(
                                 "FirstName ," +
                                 "MiddleName," +
                                 "LastName," +
                                 "Gender," +
                                 "DateOfBirth," +
                                 "StreamName," +
                                 "ClassName," +
                                 "JoiningDate," +
                                 "CreateDate," +
                                 "BirthCertificateNumber ");

            foreach (var item in appointment)
            {
                builder.AppendLine(

                        $"{item.FirstName}," +
                        $"{item.MiddleName}," +
                        $"{item.LastName}," +
                        $"{item.Gender }," +
                        $"{item.DateOfBirth }," +
                        $"{item.StreamName}," +
                        $"{item.ClassName }," +
                        $"{item.JoiningDate}," +
                        $"{item.CreateDate}," +
                        $"{item.BirthCertificateNumber }");

            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "RegistrationReport.csv");

        }

        public async Task<ActionResult> GenerateAllDumpReportPerClass(string className)
        {
            var all = await studentService.GetAll();

            var students = all.Where(x => x.ClassName == className);

            var builder = new StringBuilder();

            builder.AppendLine(
                                 "FirstName ," +
                                 "MiddleName," +
                                 "LastName," +
                                 "Gender," +
                                 "DateOfBirth," +
                                 "StreamName," +
                                 "ClassName," +
                                 "JoiningDate," +
                                 "CreateDate," +
                                 "BirthCertificateNumber ");

            foreach (var item in students)
            {
                builder.AppendLine(

                        $"{item.FirstName}," +
                        $"{item.MiddleName}," +
                        $"{item.LastName}," +
                        $"{item.Gender }," +
                        $"{item.DateOfBirth }," +
                        $"{item.StreamName}," +
                        $"{item.ClassName }," +
                        $"{item.JoiningDate}," +
                        $"{item.CreateDate}," +
                        $"{item.BirthCertificateNumber }");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "RegistrationReport.csv");

        }

    }
}