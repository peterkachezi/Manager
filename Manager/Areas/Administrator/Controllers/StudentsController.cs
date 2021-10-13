using Manager.Data.DTOs.ClassModule;
using Manager.Data.DTOs.StudentModule;
using Manager.Data.Services.ClassModule;
using Manager.Data.Services.CountyModule;
using Manager.Data.Services.HostelModule;
using Manager.Data.StreamModule;
using Manager.Data.StudentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Manager.Areas.Administrator.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Administrator/Students

        private readonly IStreamService streamService;

        private readonly IClassService classService;

        private readonly IHostelService hostelService;

        private readonly ICountyService countyService;

        private readonly IStudentService studentService;

        public StudentsController(IStreamService streamService, IHostelService hostelService, ICountyService countyService, IClassService classService, IStudentService studentService)
        {
            this.streamService = streamService;

            this.hostelService = hostelService;

            this.countyService = countyService;

            this.classService = classService;

            this.studentService = studentService;
        }

        public async Task<ActionResult> Index()
        {
            string sDate = DateTime.Now.ToString();

            string sDay = DateTime.Parse(sDate).Day.ToString();

            string sMonth = DateTime.Parse(sDate).Month.ToString();

            string sYear = DateTime.Parse(sDate).Year.ToString();

            var allstudents = await studentService.GetAll();

            //var students = allstudents.Where(x => x.CreateDate.Year == long.Parse(sYear));

            var students = allstudents;

            return View(students);
        }


        public async Task<ActionResult> RegisterStudent()
        {
            ViewBag.Stream = await streamService.GetAllStream();

            ViewBag.Hostel = await hostelService.GetAllHostels();

            ViewBag.County = await countyService.GetAllCounties();

            var Classes = (await classService.GetAll()).OrderBy(x => x.Name);

            ViewBag.Classes = Classes.GroupBy(x => x.Name).Select(g => g.First());

            return View();
        }

        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await classService.GetById(Id);

                if (data != null)
                {
                    ClassDTO file = new ClassDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreatedById = data.CreatedById,

                        CreateDate = data.CreateDate,

                        StreamId = data.StreamId,
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

        public async Task<ActionResult> GetStudentsById(Guid Id)
        {
            try
            {
                var data = await studentService.GetStudentById(Id);

                if (data != null)
                {
                    StudentDTO file = new StudentDTO()
                    {
                        Id = data.Id,

                        NewFullName = data.FirstName + " " + data.MiddleName + " " + data.LastName + " - " + data.ClassName + " " + data.StreamName,

                        MiddleName = data.MiddleName,

                        LastName = data.LastName,

                        DateOfBirth = data.DateOfBirth,

                        StreamId = data.StreamId,

                        CurrentClassId = data.CurrentClassId,

                        EntryClassId = data.EntryClassId,

                        JoiningDate = data.JoiningDate,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,

                        StreamName = data.StreamName,

                        ClassName = data.ClassName,

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
        public async Task<ActionResult> GetClassesByName(string Name)
        {
            var Classes = (await classService.GetAll()).Where(x => x.Name == Name).OrderBy(x => x.Name);

            ViewBag.Stream = Classes.GroupBy(x => x.Name).Select(g => g.First());

            return View("Index");
        }

        public async Task<ActionResult> GetStream(string Name)
        {
            var classes = (await classService.GetAll()).Where(x => x.Name == Name).OrderBy(x => x.Name);

            return Json(classes, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Create(StudentDTO studentDTO)
        {
            try
            {
                var data = (await classService.GetAll()).ToList().Where(x => x.StreamId == studentDTO.StreamId && x.Name == studentDTO.ClassName).FirstOrDefault();

                studentDTO.EntryClassId = data.Id;

                var user = User.Identity.GetUserId();

                studentDTO.CreatedById = user;

                var results = await studentService.CreateStudent(studentDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Student has been registered successfully", JsonRequestBehavior.AllowGet });

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


    }
}

