using Manager.Data.StudentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IStudentService studentService;
        public ReportsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult> GetAllStudentsAsync()
        {
            var students = await studentService.GetAll();

            return View();
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

        public async Task<ActionResult> GenerateDumpReportPerClass(string className)
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