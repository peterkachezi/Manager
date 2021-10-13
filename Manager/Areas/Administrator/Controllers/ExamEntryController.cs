using Manager.Data.DTOs.ExaminationModule;
using Manager.Data.DTOs.ExamResultsDTO;
using Manager.Data.DTOs.StudentModule;
using Manager.Data.Services.ClassModule;
using Manager.Data.Services.ExaminationModule;
using Manager.Data.Services.GradingSystemHumanityModule;
using Manager.Data.Services.GradingSystemLanguagesModule;
using Manager.Data.Services.GradingSystemMathematicsModule;
using Manager.Data.Services.GradingSystemSciencesModule;
using Manager.Data.Services.GradingSystemTechnicalsModule;
using Manager.Data.Services.SubjectModule;
using Manager.Data.StreamModule;
using Manager.Data.StudentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ExamEntryController : Controller
    {
        private readonly IExaminationService examinationService;

        private readonly ISciencesService sciencesService;

        private readonly ILanguagesService languagesService;

        private readonly IMathsService mathsService;

        private readonly IHumanityService humanityService;

        private readonly ITechnicalService technicalService;

        private readonly IStreamService streamService;

        private readonly IClassService classService;

        private readonly IStudentService studentService;

        private readonly ISubjectService subjectService;

        public ExamEntryController(IExaminationService examinationService,
            ILanguagesService languagesService,
            ISciencesService sciencesService, IStreamService streamService,
            IClassService classService, IStudentService studentService,
            IMathsService mathsService, IHumanityService humanityService,
            ITechnicalService technicalService, ISubjectService subjectService)
        {
            this.examinationService = examinationService;

            this.sciencesService = sciencesService;

            this.streamService = streamService;

            this.classService = classService;

            this.studentService = studentService;

            this.languagesService = languagesService;

            this.mathsService = mathsService;

            this.humanityService = humanityService;

            this.technicalService = technicalService;

            this.subjectService = subjectService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> SubmitTechnicals(AnyExamDTO anyExamDTO)
        {
            var get_grading_details = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(anyExamDTO.Marks) <= 0 && s.ToMarks.CompareTo(anyExamDTO.Marks) >= 0).FirstOrDefault();

            var buildingConstruction = new BuildingConstructionDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = anyExamDTO.Term,

                CreatedById = anyExamDTO.CreatedById,
            };

            var computerStudies = new ComputerDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var bussinessManagement = new BusinessDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var agriculture = new AgricultureDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var artandDesign = new ArtDesignDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var music = new MusicDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var French = new FrenchDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var germany = new GermanDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };

            var homescience = new HomeScienceDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading_details.GradeName,

                Points = get_grading_details.Points,

                Term = "1",

                CreatedById = anyExamDTO.CreatedById,
            };


            if (anyExamDTO.Subject == "Building Construction")
            {
                var submitbuildingConstruction = await examinationService.SubmitBuildingConstructionResults(buildingConstruction);

            }

            if (anyExamDTO.Subject == "Music")
            {
                var submitmusic = await examinationService.SubmitMusicResults(music);

            }


            if (anyExamDTO.Subject == "Art Design")
            {
                var submitartandDesign = await examinationService.SubmitArtDesignResults(artandDesign);

            }

            if (anyExamDTO.Subject == "Agriculture")
            {
                var submitagriculture = await examinationService.SubmitAgricultureResults(agriculture);

            }

            if (anyExamDTO.Subject == "French")
            {
                var submitFrench = await examinationService.SubmitFrenchResults(French);

            }

            if (anyExamDTO.Subject == "Computer Studies")
            {
                var submitcomputerStudies = await examinationService.SubmitComputerResults(computerStudies);

            }

            if (anyExamDTO.Subject == "Bussiness Management")
            {
                var submitbussinessManagement = await examinationService.SubmitBusinessResults(bussinessManagement);

            }

            if (anyExamDTO.Subject == "Home Science")
            {
                var submithomescience = await examinationService.SubmitHomescienceResults(homescience);

            }

            if (anyExamDTO.Subject == "Germany")
            {
                var submitgermany = await examinationService.SubmitGermanResults(germany);

            }

            return View();
        }

        public async Task<ActionResult> SubmitSciences(AnyExamDTO anyExamDTO)
        {
            var get_grading = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(anyExamDTO.Marks) <= 0 && s.ToMarks.CompareTo(anyExamDTO.Marks) >= 0).FirstOrDefault();

            var chemestry = new ChemistryDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading.GradeName,

                Points = get_grading.Points,

                Term = anyExamDTO.Term,

                CreatedById = anyExamDTO.CreatedById,
            };

            var biology = new BiologyDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading.GradeName,

                Points = get_grading.Points,

                Term = anyExamDTO.Term,

                CreatedById = anyExamDTO.CreatedById,
            };

            var physics = new PhysicsDTO
            {
                StudentId = anyExamDTO.StudentId,

                ClassId = anyExamDTO.ClassId,

                StreamId = anyExamDTO.StreamId,

                Marks = anyExamDTO.Marks,

                Grade = get_grading.GradeName,

                Points = get_grading.Points,

                Term = anyExamDTO.Term,

                CreatedById = anyExamDTO.CreatedById,
            };


            if (anyExamDTO.Subject == "Chemestry")
            {
                var submitchemistry = await examinationService.SubmitChemestryResults(chemestry);

            }

            if (anyExamDTO.Subject == "Biology")
            {
                var submitbiology = await examinationService.SubmitBiologyResults(biology);

            }

            if (anyExamDTO.Subject == "Physics")
            {
                var submitphysics = await examinationService.SubmitPhysicsResults(physics);

            }

            return View();
        }

        public async Task<ActionResult> SubmitHumanities(AnyExamDTO anyExamDTO)
        {
            try
            {
                var get_grading = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(anyExamDTO.Marks) <= 0 && s.ToMarks.CompareTo(anyExamDTO.Marks) >= 0).FirstOrDefault();

                var history = new HistoryDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Marks = anyExamDTO.Marks,

                    Grade = get_grading.GradeName,

                    Points = get_grading.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };

                var geography = new GeographyDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Marks = anyExamDTO.Marks,

                    Grade = get_grading.GradeName,

                    Points = get_grading.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };


                var CRE = new CREDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Marks = anyExamDTO.Marks,

                    Grade = get_grading.GradeName,

                    Points = get_grading.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };

                if (anyExamDTO.Subject == "Geography")
                {
                    var submitgeography = await examinationService.SubmitGeographyResults(geography);

                }


                if (anyExamDTO.Subject == "History & Government")
                {
                    var submithistory = await examinationService.SubmitHistoryResults(history);

                }

                if (anyExamDTO.Subject == "CRE")
                {
                    var submitCRE = await examinationService.SubmitCREResults(CRE);

                }

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitLanguages(AnyExamDTO anyExamDTO)
        {
            try
            {
                var get_grading = (await languagesService.GetAll()).Where(s => s.FromMarks.CompareTo(anyExamDTO.Marks) <= 0 && s.ToMarks.CompareTo(anyExamDTO.Marks) >= 0).FirstOrDefault();


                var english = new EnglishDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Marks = anyExamDTO.Marks,

                    Grade = get_grading.GradeName,

                    Points = get_grading.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };


                var kiswahili = new KiswahiliDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Grade = get_grading.GradeName,

                    Marks = anyExamDTO.Marks,

                    Points = get_grading.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };

                if (anyExamDTO.Subject == "Kiswahili")
                {
                    var submitKiswahili = await examinationService.SubmitKiswahiliResults(kiswahili);

                }

                if (anyExamDTO.Subject == "English")
                {
                    var submitenglish = await examinationService.SubmitEnglishResults(english);

                }





                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitMathematics(AnyExamDTO anyExamDTO)
        {
            try
            {
                var get_maths = (await mathsService.GetAll()).Where(s => s.FromMarks.CompareTo(anyExamDTO.Marks) <= 0 && s.ToMarks.CompareTo(anyExamDTO.Marks) >= 0).FirstOrDefault();


                var math = new MathDTO
                {
                    StudentId = anyExamDTO.StudentId,

                    ClassId = anyExamDTO.ClassId,

                    StreamId = anyExamDTO.StreamId,

                    Grade = get_maths.GradeName,

                    Marks = anyExamDTO.Marks,

                    Points = get_maths.Points,

                    Term = anyExamDTO.Term,

                    CreatedById = anyExamDTO.CreatedById,
                };

                var submitKiswahili = await examinationService.SubmitMathematicsResults(math);

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitResult(AnyExamDTO anyExamDTO)
        {
            var user = User.Identity.GetUserId();

            anyExamDTO.CreatedById = user;

            if (anyExamDTO.Subject == "Building Construction" || anyExamDTO.Subject == "Music" || anyExamDTO.Subject == "Art Design" || anyExamDTO.Subject == "Agriculture" ||

                anyExamDTO.Subject == "French" || anyExamDTO.Subject == "Computer Studies" || anyExamDTO.Subject == "Bussiness Management"

                || anyExamDTO.Subject == "Home Science" || anyExamDTO.Subject == "Germany")
            {
                var technicals = await SubmitTechnicals(anyExamDTO);

            }


            if (anyExamDTO.Subject == "Biology" || anyExamDTO.Subject == "Chemestry" || anyExamDTO.Subject == "Physics")
            {
                var sciences = await SubmitSciences(anyExamDTO);
            }


            if (anyExamDTO.Subject == "Geography" || anyExamDTO.Subject == "History & Government" || anyExamDTO.Subject == "CRE")
            {
                var humanities = await SubmitHumanities(anyExamDTO);
            }


            if (anyExamDTO.Subject == "Kiswahili" || anyExamDTO.Subject == "English")
            {
                var languages = await SubmitLanguages(anyExamDTO);
            }

            if (anyExamDTO.Subject == "Mathematics")
            {
                var mathematics = await SubmitMathematics(anyExamDTO);
            }


            return Json(new { success = true, responseText = "Marks has been successfully submitted", JsonRequestBehavior.AllowGet });

        }

        public async Task<ActionResult> ResultsEntry()
        {
            ViewBag.Subjects = await subjectService.GetAllSubject();

            return View();
        }

        public async Task<JsonResult> GetStudentByAdmNo(int AdmNo)
        {
            var data = await studentService.GetAllByAdmNo(AdmNo);

            if (data != null)
            {
                StudentDTO employee = new StudentDTO
                {
                    Id = data.Id,

                    FirstName = data.FirstName,

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

                    ClassName = data.ClassName + " " + data.StreamName,

                    AdmNumber = data.AdmNumber,

                    Gender = data.Gender,

                    ClassTeacher = data.ClassTeacher,
                };
                return Json(new { success = true, responseText = employee }, JsonRequestBehavior.AllowGet);
                              

            }
            return Json(new { success = false, responseText = "The admission number could not be found", JsonRequestBehavior.AllowGet });



        }

        public async Task<ActionResult> GetStudentByAdmNo1(int AdmNo)
        {
            try
            {
                var data = await studentService.GetAllByAdmNo(AdmNo);

                if (data != null)

                {
                    StudentDTO file = new StudentDTO()
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

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

                        ClassName = data.ClassName + " " + data.StreamName,

                        AdmNumber = data.AdmNumber,

                        Gender = data.Gender,

                        ClassTeacher = data.ClassTeacher,
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