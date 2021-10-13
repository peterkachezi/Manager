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
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ExaminationsController : Controller
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


        public ExaminationsController(IExaminationService examinationService,
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

        public async Task<ActionResult> Index()
        {

            var Classes = (await classService.GetAll()).OrderBy(x => x.Name);

            ViewBag.Classes = Classes.GroupBy(x => x.Name).Select(g => g.First());

            //var student = all.Where(x => x.StreamName == StreamName && x.ClassName == ClassName);

            return View();
        }

    


        public async Task<ActionResult> GetStudents(Guid? StreamName, string ClassName)
        {

            if (StreamName == null || StreamName == Guid.Empty || ClassName == "")
            {
                TempData["Error"] = "Please select class and stream";

                return RedirectToAction("Index");
            }

            Guid StreamId = StreamName.Value;

            var all = (await studentService.GetAll());

            var student = all.Where(x => x.StreamId == StreamId && x.ClassName == ClassName);

            var getemployeeId = all.Where(x => x.StreamId == StreamId && x.ClassName == ClassName).FirstOrDefault().EmployeeId;

            var classdetails = (await classService.GetAll()).Where(x => x.EmployeeId == getemployeeId).FirstOrDefault();

            ViewBag.Teacher = classdetails.EmployeeName;

            ViewBag.ClassStream = classdetails.Name + " " + classdetails.StreamName;

            return View(student);
        }

        public async Task<ActionResult> SubmitLanguages(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_english = (await languagesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.English) <= 0 && s.ToMarks.CompareTo(examinationDTO.English) >= 0).FirstOrDefault();

                var get_kiswahili = (await languagesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Kiswahili) <= 0 && s.ToMarks.CompareTo(examinationDTO.Kiswahili) >= 0).FirstOrDefault();

                var english = new EnglishDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.English,

                    Grade = get_english.GradeName,

                    Points = get_english.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };


                var kiswahili = new KiswahiliDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Grade = get_kiswahili.GradeName,

                    Marks = examinationDTO.Kiswahili,
                    Points = get_kiswahili.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var submitenglish = await examinationService.SubmitEnglishResults(english);


                var submitKiswahili = await examinationService.SubmitKiswahiliResults(kiswahili);

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitMathematics(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_maths = (await mathsService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Mathematics) <= 0 && s.ToMarks.CompareTo(examinationDTO.Mathematics) >= 0).FirstOrDefault();


                var math = new MathDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Grade = get_maths.GradeName,

                    Marks = examinationDTO.Mathematics,

                    Points = get_maths.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
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

        public async Task<ActionResult> SubmitHumanities(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_history = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.HistoryGovernment) <= 0 && s.ToMarks.CompareTo(examinationDTO.HistoryGovernment) >= 0).FirstOrDefault();

                var get_geography = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Geography) <= 0 && s.ToMarks.CompareTo(examinationDTO.Geography) >= 0).FirstOrDefault();

                var get_CRE = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.CRE) <= 0 && s.ToMarks.CompareTo(examinationDTO.CRE) >= 0).FirstOrDefault();


                var history = new HistoryDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.HistoryGovernment,

                    Grade = get_history.GradeName,

                    Points = get_history.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var geography = new GeographyDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Geography,

                    Grade = get_geography.GradeName,

                    Points = get_geography.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };


                var CRE = new CREDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.CRE,

                    Grade = get_CRE.GradeName,

                    Points = get_CRE.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };


                var submithistory = await examinationService.SubmitHistoryResults(history);

                var submitgeography = await examinationService.SubmitGeographyResults(geography);

                var submitCRE = await examinationService.SubmitCREResults(CRE);

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitSciences(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_chem = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Chemistry) <= 0 && s.ToMarks.CompareTo(examinationDTO.Chemistry) >= 0).FirstOrDefault();

                var get_Biology = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Biology) <= 0 && s.ToMarks.CompareTo(examinationDTO.Biology) >= 0).FirstOrDefault();

                var get_Physics = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Physics) <= 0 && s.ToMarks.CompareTo(examinationDTO.Physics) >= 0).FirstOrDefault();


                var chemestry = new ChemistryDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Chemistry,

                    Grade = get_chem.GradeName,

                    Points = get_chem.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var biology = new BiologyDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Biology,

                    Grade = get_Biology.GradeName,

                    Points = get_Biology.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var physics = new PhysicsDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Physics,

                    Grade = get_Physics.GradeName,

                    Points = get_Physics.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };


                var submitchemistry = await examinationService.SubmitChemestryResults(chemestry);

                var submitbiology = await examinationService.SubmitBiologyResults(biology);

                var submitphysics = await examinationService.SubmitPhysicsResults(physics);


                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> SubmitTechnicals(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_computer = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.ComputerStudies) <= 0 && s.ToMarks.CompareTo(examinationDTO.ComputerStudies) >= 0).FirstOrDefault();

                var get_Business = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.BussinessManagement) <= 0 && s.ToMarks.CompareTo(examinationDTO.BussinessManagement) >= 0).FirstOrDefault();

                var get_agriculture = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Agriculture) <= 0 && s.ToMarks.CompareTo(examinationDTO.Agriculture) >= 0).FirstOrDefault();

                var get_ArtandDesign = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.ArtDesign) <= 0 && s.ToMarks.CompareTo(examinationDTO.ArtDesign) >= 0).FirstOrDefault();

                var get_BuildingConstruction = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.BuildingConstruction) <= 0 && s.ToMarks.CompareTo(examinationDTO.BuildingConstruction) >= 0).FirstOrDefault();

                var get_music = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Music) <= 0 && s.ToMarks.CompareTo(examinationDTO.Music) >= 0).FirstOrDefault();

                var get_French = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.French) <= 0 && s.ToMarks.CompareTo(examinationDTO.French) >= 0).FirstOrDefault();

                var get_Germany = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.German) <= 0 && s.ToMarks.CompareTo(examinationDTO.German) >= 0).FirstOrDefault();

                var get_homescience = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.HomeScience) <= 0 && s.ToMarks.CompareTo(examinationDTO.HomeScience) >= 0).FirstOrDefault();


                var computerStudies = new ComputerDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.ComputerStudies,

                    Grade = get_computer.GradeName,

                    Points = get_computer.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var bussinessManagement = new BusinessDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.BussinessManagement,

                    Grade = get_Business.GradeName,

                    Points = get_Business.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var agriculture = new AgricultureDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Agriculture,

                    Grade = get_agriculture.GradeName,

                    Points = get_agriculture.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var artandDesign = new ArtDesignDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.ArtDesign,

                    Grade = get_ArtandDesign.GradeName,

                    Points = get_ArtandDesign.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var buildingConstruction = new BuildingConstructionDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.BuildingConstruction,

                    Grade = get_BuildingConstruction.GradeName,

                    Points = get_BuildingConstruction.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var music = new MusicDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.Music,

                    Grade = get_music.GradeName,

                    Points = get_music.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var French = new FrenchDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.French,

                    Grade = get_French.GradeName,

                    Points = get_French.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var germany = new GermanDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.German,

                    Grade = get_Germany.GradeName,

                    Points = get_Germany.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };

                var homescience = new HomeScienceDTO
                {
                    StudentId = examinationDTO.StudentId,

                    ClassId = examinationDTO.ClassId,

                    StreamId = examinationDTO.StreamId,

                    Marks = examinationDTO.HomeScience,

                    Grade = get_homescience.GradeName,

                    Points = get_homescience.Points,

                    Term = "1",

                    CreatedById = examinationDTO.CreatedById,
                };


                var submitcomputerStudies = await examinationService.SubmitComputerResults(computerStudies);

                var submitbussinessManagement = await examinationService.SubmitBusinessResults(bussinessManagement);

                var submitagriculture = await examinationService.SubmitAgricultureResults(agriculture);

                var submitartandDesign = await examinationService.SubmitArtDesignResults(artandDesign);

                var submitbuildingConstruction = await examinationService.SubmitBuildingConstructionResults(buildingConstruction);

                var submitmusic = await examinationService.SubmitMusicResults(music);

                var submitFrench = await examinationService.SubmitFrenchResults(French);

                var submitgermany = await examinationService.SubmitGermanResults(germany);

                var submithomescience = await examinationService.SubmitHomescienceResults(homescience);


                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> Create(ExaminationDTO examinationDTO)
        {
            try
            {
                var get_english = (await languagesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.English) <= 0 && s.ToMarks.CompareTo(examinationDTO.English) >= 0).FirstOrDefault();

                if (get_english == null)
                {
                    return Json(new { success = false, responseText = "Grading system for languages has not been configured", JsonRequestBehavior.AllowGet });
                }


                var get_kiswahili = (await languagesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Kiswahili) <= 0 && s.ToMarks.CompareTo(examinationDTO.Kiswahili) >= 0).FirstOrDefault();

                if (get_kiswahili == null)
                {
                    return Json(new { success = false, responseText = "Grading system for languages has not been configured", JsonRequestBehavior.AllowGet });

                }


                var get_maths = (await mathsService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Mathematics) <= 0 && s.ToMarks.CompareTo(examinationDTO.Mathematics) >= 0).FirstOrDefault();

                if (get_maths == null)
                {
                    return Json(new { success = false, responseText = "Grading system for mathematics has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_history = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.HistoryGovernment) <= 0 && s.ToMarks.CompareTo(examinationDTO.HistoryGovernment) >= 0).FirstOrDefault();

                if (get_history == null)
                {
                    return Json(new { success = false, responseText = "Grading system for humanities has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_geography = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Geography) <= 0 && s.ToMarks.CompareTo(examinationDTO.Geography) >= 0).FirstOrDefault();

                if (get_geography == null)
                {
                    return Json(new { success = false, responseText = "Grading system for humanities has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_CRE = (await humanityService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.CRE) <= 0 && s.ToMarks.CompareTo(examinationDTO.CRE) >= 0).FirstOrDefault();

                if (get_CRE == null)
                {
                    return Json(new { success = false, responseText = "Grading system for humanities has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_chem = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Chemistry) <= 0 && s.ToMarks.CompareTo(examinationDTO.Chemistry) >= 0).FirstOrDefault();

                if (get_chem == null)
                {
                    return Json(new { success = false, responseText = "Grading system for sciences has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_Biology = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Biology) <= 0 && s.ToMarks.CompareTo(examinationDTO.Biology) >= 0).FirstOrDefault();

                if (get_Biology == null)
                {
                    return Json(new { success = false, responseText = "Grading system for sciences has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_Physics = (await sciencesService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Physics) <= 0 && s.ToMarks.CompareTo(examinationDTO.Physics) >= 0).FirstOrDefault();

                if (get_Physics == null)
                {
                    return Json(new { success = false, responseText = "Grading system for sciences has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_computer = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.ComputerStudies) <= 0 && s.ToMarks.CompareTo(examinationDTO.ComputerStudies) >= 0).FirstOrDefault();

                if (get_computer == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_Business = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.BussinessManagement) <= 0 && s.ToMarks.CompareTo(examinationDTO.BussinessManagement) >= 0).FirstOrDefault();

                if (get_Business == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_agriculture = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Agriculture) <= 0 && s.ToMarks.CompareTo(examinationDTO.Agriculture) >= 0).FirstOrDefault();

                if (get_agriculture == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_ArtandDesign = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.ArtDesign) <= 0 && s.ToMarks.CompareTo(examinationDTO.ArtDesign) >= 0).FirstOrDefault();

                if (get_ArtandDesign == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_BuildingConstruction = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.BuildingConstruction) <= 0 && s.ToMarks.CompareTo(examinationDTO.BuildingConstruction) >= 0).FirstOrDefault();

                if (get_BuildingConstruction == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_music = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.Music) <= 0 && s.ToMarks.CompareTo(examinationDTO.Music) >= 0).FirstOrDefault();

                if (get_music == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_French = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.French) <= 0 && s.ToMarks.CompareTo(examinationDTO.French) >= 0).FirstOrDefault();

                if (get_French == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_Germany = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.German) <= 0 && s.ToMarks.CompareTo(examinationDTO.German) >= 0).FirstOrDefault();

                if (get_Germany == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }

                var get_homescience = (await technicalService.GetAll()).Where(s => s.FromMarks.CompareTo(examinationDTO.HomeScience) <= 0 && s.ToMarks.CompareTo(examinationDTO.HomeScience) >= 0).FirstOrDefault();

                if (get_homescience == null)
                {
                    return Json(new { success = false, responseText = "Grading system for technicals has not been configured properly", JsonRequestBehavior.AllowGet });

                }


                var user = User.Identity.GetUserId();

                examinationDTO.CreatedById = user;


                var languages = await SubmitLanguages(examinationDTO);

                var maths = await SubmitMathematics(examinationDTO);

                var Sciences = await SubmitSciences(examinationDTO);

                var technicals = await SubmitTechnicals(examinationDTO);

                var humanities = await SubmitHumanities(examinationDTO);


                return Json(new { success = true, responseText = "Marks has been successfully submitted", JsonRequestBehavior.AllowGet });



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
                var data = await examinationService.GetById(Id);

                if (data != null)
                {
                    ExaminationDTO file = new ExaminationDTO()
                    {
                        Id = data.Id,

                        StudentId = data.StudentId,

                        Music = data.Music,

                        Biology = data.Biology,

                        Chemistry = data.Chemistry,

                        Physics = data.Physics,

                        Agriculture = data.Agriculture,

                        ComputerStudies = data.ComputerStudies,

                        BussinessManagement = data.BussinessManagement,

                        Kiswahili = data.Kiswahili,

                        CRE = data.CRE,

                        ArtDesign = data.ArtDesign,

                        HomeScience = data.HomeScience,

                        BuildingConstruction = data.BuildingConstruction,

                        French = data.French,

                        German = data.German,

                        Geography = data.Geography,

                        CreateDate = data.CreateDate,

                        English = data.English,

                        Mathematics = data.Mathematics,

                        HistoryGovernment = data.HistoryGovernment,

                        UpdatedDate = data.UpdatedDate,

                        UpdatedById = data.UpdatedById,

                        CreatedById = data.CreatedById,

                        StudentName = data.StudentName,

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




    }
}