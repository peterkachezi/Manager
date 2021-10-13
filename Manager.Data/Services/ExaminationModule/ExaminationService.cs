using Manager.Data.DTOs.ExaminationModule;
using Manager.Data.DTOs.ExamResultsDTO;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExaminationModule
{
    public class ExaminationService : IExaminationService
    {
        private readonly StudentEntities context;
        public ExaminationService(StudentEntities context)
        {
            this.context = context;
        }
        //public async Task<List<ExaminationDTO>> GetAll()
        //{
        //    try
        //    {
        //        var exam = await context.Examinations.ToListAsync();

        //        var exams = new List<ExaminationDTO>();

        //        foreach (var item in exam)
        //        {
        //            var data = new ExaminationDTO
        //            {
        //                Id = item.Id,

        //                StudentId = item.StudentId,

        //                Music = item.Music,

        //                Biology = item.Biology,

        //                Chemestry = item.Chemestry,

        //                Physics = item.Physics,

        //                Agriculture = item.Agriculture,

        //                ComputerStudies = item.ComputerStudies,

        //                BussinessManagement = item.BussinessManagement,

        //                Kiswahili = item.Kiswahili,

        //                CRE = item.CRE,

        //                ArtDesign = item.ArtDesign,

        //                HomeScience = item.HomeScience,

        //                BuildingConstruction = item.BuildingConstruction,

        //                French = item.French,

        //                German = item.German,

        //                Geography = item.Geography,

        //                CreateDate = item.CreateDate,

        //                English = item.English,

        //                Mathematics = item.Mathematics,

        //                HistoryGovernment = item.HistoryGovernment,


        //                UpdatedDate = item.UpdatedDate,

        //                UpdatedById = item.UpdatedById,

        //                CreatedById = item.CreatedById,

        //                StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

        //                StreamName = item.Student.Stream.Name,

        //                ClassName = item.Student.InstitutionClass.Name,

        //            };

        //            exams.Add(data);
        //        }
        //        return exams;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);

        //        return null;

        //    }
        //}
        public async Task<List<TestDTO>> Test()
        {
            try
            {
                var exam = await context.Tests.ToListAsync();

                var exams = new List<TestDTO>();

                foreach (var item in exam)
                {
                    var data = new TestDTO
                    {
                        Id = item.Id,
                        FromNo = item.FromNo,
                        ToNo = item.ToNo,
                        Mark = item.Mark,

                    };

                    exams.Add(data);
                }
                return exams;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;

            }
        }
        //public async Task<ExaminationDTO> GetById(Guid Id)
        //{
        //    try
        //    {
        //        var results = await context.Examinations.FindAsync(Id);

        //        return new ExaminationDTO
        //        {
        //            Id = results.Id,

        //            StudentId = results.StudentId,

        //            Music = results.Music,

        //            Biology = results.Biology,

        //            Chemestry = results.Chemestry,

        //            Physics = results.Physics,

        //            Agriculture = results.Agriculture,

        //            ComputerStudies = results.ComputerStudies,

        //            BussinessManagement = results.BussinessManagement,

        //            Kiswahili = results.Kiswahili,

        //            CRE = results.CRE,

        //            ArtDesign = results.ArtDesign,

        //            HomeScience = results.HomeScience,

        //            BuildingConstruction = results.BuildingConstruction,

        //            French = results.French,

        //            German = results.German,

        //            Geography = results.Geography,

        //            CreateDate = results.CreateDate,

        //            English = results.English,

        //            Mathematics = results.Mathematics,

        //            HistoryGovernment = results.HistoryGovernment,

        //            UpdatedDate = results.UpdatedDate,

        //            UpdatedById = results.UpdatedById,

        //            CreatedById = results.CreatedById,

        //            StudentName = results.Student.FirstName + " " + results.Student.MiddleName + " " + results.Student.LastName,

        //            StreamName = results.Student.Stream.Name,

        //            ClassName = results.Student.InstitutionClass.Name,

        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);

        //        return null;

        //    }
        //}
        public async Task<bool> Update(ExaminationDTO examinationDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Examinations.FindAsync(examinationDTO.Id);
                    {

                        s.Music = examinationDTO.Music;

                        s.Biology = examinationDTO.Biology;

                        s.Chemestry = examinationDTO.Chemistry;

                        s.Physics = examinationDTO.Physics;

                        s.Agriculture = examinationDTO.Agriculture;

                        s.ComputerStudies = examinationDTO.ComputerStudies;

                        s.BussinessManagement = examinationDTO.BussinessManagement;

                        s.Kiswahili = examinationDTO.Kiswahili;

                        s.CRE = examinationDTO.CRE;

                        s.ArtDesign = examinationDTO.ArtDesign;

                        s.HomeScience = examinationDTO.HomeScience;

                        s.BuildingConstruction = examinationDTO.BuildingConstruction;

                        s.French = examinationDTO.French;

                        s.German = examinationDTO.German;

                        s.Geography = examinationDTO.Geography;

                        s.English = examinationDTO.English;

                        s.Mathematics = examinationDTO.Mathematics;

                        s.HistoryGovernment = examinationDTO.HistoryGovernment;

                        s.UpdatedDate = DateTime.Now;

                        s.UpdatedById = examinationDTO.UpdatedById;

                        s.Points = examinationDTO.Points;

                        s.Grade = examinationDTO.Grade;

                    }
                    transaction.Commit();

                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

        }
        public async Task<bool> SubmitEnglishResults(EnglishDTO englishDTO)
        {
            try
            {
                var s = new ResultsEnglish
                {
                    Id = Guid.NewGuid(),

                    Term = englishDTO.Term,

                    StreamId = englishDTO.StreamId,

                    ClassId = englishDTO.ClassId,

                    StudentId = englishDTO.StudentId,

                    Marks = englishDTO.Marks,

                    Grade = englishDTO.Grade,

                    Points = englishDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = englishDTO.CreatedById,

                };

                context.ResultsEnglishes.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitKiswahiliResults(KiswahiliDTO kiswahiliDTO)
        {
            try
            {
                var s = new ResultsKiswahili
                {
                    Id = Guid.NewGuid(),

                    Term = kiswahiliDTO.Term,

                    StreamId = kiswahiliDTO.StreamId,

                    ClassId = kiswahiliDTO.ClassId,

                    StudentId = kiswahiliDTO.StudentId,

                    Marks = kiswahiliDTO.Marks,

                    Grade = kiswahiliDTO.Grade,

                    Points = kiswahiliDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = kiswahiliDTO.CreatedById,

                };

                context.ResultsKiswahilis.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitMathematicsResults(MathDTO mathDTO)
        {
            try
            {
                var s = new ResultsMath
                {
                    Id = Guid.NewGuid(),

                    Term = mathDTO.Term,

                    StreamId = mathDTO.StreamId,

                    ClassId = mathDTO.ClassId,

                    StudentId = mathDTO.StudentId,

                    Marks = mathDTO.Marks,

                    Grade = mathDTO.Grade,

                    Points = mathDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = mathDTO.CreatedById,

                };

                context.ResultsMaths.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitHistoryResults(HistoryDTO historyDTO)
        {
            try
            {
                var s = new ResultsHistory
                {
                    Id = Guid.NewGuid(),

                    Term = historyDTO.Term,

                    StreamId = historyDTO.StreamId,

                    ClassId = historyDTO.ClassId,

                    StudentId = historyDTO.StudentId,

                    Marks = historyDTO.Marks,

                    Grade = historyDTO.Grade,

                    Points = historyDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = historyDTO.CreatedById,

                };

                context.ResultsHistories.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitGeographyResults(GeographyDTO geographyDTO)
        {
            try
            {
                var s = new ResultsGeography
                {
                    Id = Guid.NewGuid(),

                    Term = geographyDTO.Term,

                    StreamId = geographyDTO.StreamId,

                    ClassId = geographyDTO.ClassId,

                    StudentId = geographyDTO.StudentId,

                    Marks = geographyDTO.Marks,

                    Grade = geographyDTO.Grade,

                    Points = geographyDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = geographyDTO.CreatedById,

                };
                context.ResultsGeographies.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitCREResults(CREDTO cREDTO)
        {
            try
            {
                var s = new ResultsCRE
                {
                    Id = Guid.NewGuid(),

                    Term = cREDTO.Term,

                    StreamId = cREDTO.StreamId,

                    ClassId = cREDTO.ClassId,

                    StudentId = cREDTO.StudentId,

                    Marks = cREDTO.Marks,

                    Grade = cREDTO.Grade,

                    Points = cREDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = cREDTO.CreatedById,

                };
                context.ResultsCREs.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitComputerResults(ComputerDTO computerDTO)
        {
            try
            {
                var s = new ResultsComputerStudy
                {
                    Id = Guid.NewGuid(),

                    Term = computerDTO.Term,

                    StreamId = computerDTO.StreamId,

                    ClassId = computerDTO.ClassId,

                    StudentId = computerDTO.StudentId,

                    Marks = computerDTO.Marks,

                    Grade = computerDTO.Grade,

                    Points = computerDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = computerDTO.CreatedById,

                };
                context.ResultsComputerStudies.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitAgricultureResults(AgricultureDTO agricultureDTO)
        {
            try
            {
                var s = new ResultsAgriculture
                {
                    Id = Guid.NewGuid(),

                    Term = agricultureDTO.Term,

                    StreamId = agricultureDTO.StreamId,

                    ClassId = agricultureDTO.ClassId,

                    StudentId = agricultureDTO.StudentId,

                    Grade = agricultureDTO.Grade,

                    Marks = agricultureDTO.Marks,

                    Points = agricultureDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = agricultureDTO.CreatedById,

                };
                context.ResultsAgricultures.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitBusinessResults(BusinessDTO businessDTO)
        {
            try
            {
                var s = new ResultsBusiness
                {
                    Id = Guid.NewGuid(),

                    Term = businessDTO.Term,

                    StreamId = businessDTO.StreamId,

                    ClassId = businessDTO.ClassId,

                    StudentId = businessDTO.StudentId,

                    Marks = businessDTO.Marks,

                    Grade = businessDTO.Grade,

                    Points = businessDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = businessDTO.CreatedById,

                };
                context.ResultsBusinesses.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitFrenchResults(FrenchDTO frenchDTO)
        {
            try
            {
                var s = new ResultsFrench
                {
                    Id = Guid.NewGuid(),

                    Term = frenchDTO.Term,

                    StreamId = frenchDTO.StreamId,

                    ClassId = frenchDTO.ClassId,

                    StudentId = frenchDTO.StudentId,

                    Marks = frenchDTO.Marks,

                    Grade = frenchDTO.Grade,

                    Points = frenchDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = frenchDTO.CreatedById,

                };
                context.ResultsFrenches.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitGermanResults(GermanDTO germanDTO)
        {
            try
            {
                var s = new ResultsGerman
                {
                    Id = Guid.NewGuid(),

                    Term = germanDTO.Term,

                    StreamId = germanDTO.StreamId,

                    ClassId = germanDTO.ClassId,

                    StudentId = germanDTO.StudentId,

                    Marks = germanDTO.Marks,

                    Grade = germanDTO.Grade,

                    Points = germanDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = germanDTO.CreatedById,

                };
                context.ResultsGermen.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitHomescienceResults(HomeScienceDTO homeScienceDTO)
        {
            try
            {
                var s = new ResultsHomeScience
                {
                    Id = Guid.NewGuid(),

                    Term = homeScienceDTO.Term,

                    StreamId = homeScienceDTO.StreamId,

                    ClassId = homeScienceDTO.ClassId,

                    StudentId = homeScienceDTO.StudentId,

                    Marks = homeScienceDTO.Marks,

                    Grade = homeScienceDTO.Grade,

                    Points = homeScienceDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = homeScienceDTO.CreatedById,

                };
                context.ResultsHomeSciences.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitBiologyResults(BiologyDTO biologyDTO)
        {
            try
            {
                var s = new ResultsBiology
                {
                    Id = Guid.NewGuid(),

                    Term = biologyDTO.Term,

                    StreamId = biologyDTO.StreamId,

                    ClassId = biologyDTO.ClassId,

                    StudentId = biologyDTO.StudentId,

                    Marks = biologyDTO.Marks,

                    Grade = biologyDTO.Grade,

                    Points = biologyDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = biologyDTO.CreatedById,

                };
                context.ResultsBiologies.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitMusicResults(MusicDTO musicDTO)
        {
            try
            {
                var s = new ResultsMusic
                {
                    Id = Guid.NewGuid(),

                    Term = musicDTO.Term,

                    StreamId = musicDTO.StreamId,

                    ClassId = musicDTO.ClassId,

                    StudentId = musicDTO.StudentId,

                    Marks = musicDTO.Marks,

                    Grade = musicDTO.Grade,

                    Points = musicDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = musicDTO.CreatedById,

                };
                context.ResultsMusics.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitChemestryResults(ChemistryDTO chemistryDTO)
        {
            try
            {
                var s = new ResultsChemistry
                {
                    Id = Guid.NewGuid(),

                    Term = chemistryDTO.Term,

                    StreamId = chemistryDTO.StreamId,

                    ClassId = chemistryDTO.ClassId,

                    StudentId = chemistryDTO.StudentId,

                    Marks = chemistryDTO.Marks,

                    Grade = chemistryDTO.Grade,

                    Points = chemistryDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = chemistryDTO.CreatedById,

                };
                context.ResultsChemistries.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitPhysicsResults(PhysicsDTO physicsDTO)
        {
            try
            {
                var s = new ResultsPhysic
                {
                    Id = Guid.NewGuid(),

                    Term = physicsDTO.Term,

                    StreamId = physicsDTO.StreamId,

                    ClassId = physicsDTO.ClassId,

                    StudentId = physicsDTO.StudentId,

                    Marks = physicsDTO.Marks,

                    Grade = physicsDTO.Grade,

                    Points = physicsDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = physicsDTO.CreatedById,

                };
                context.ResultsPhysics.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitArtDesignResults(ArtDesignDTO artDesignDTO)
        {
            try
            {
                var s = new ResultsArtDesign
                {
                    Id = Guid.NewGuid(),

                    Term = artDesignDTO.Term,

                    StreamId = artDesignDTO.StreamId,

                    ClassId = artDesignDTO.ClassId,

                    StudentId = artDesignDTO.StudentId,

                    Marks = artDesignDTO.Marks,

                    Grade = artDesignDTO.Grade,

                    Points = artDesignDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = artDesignDTO.CreatedById,

                };
                context.ResultsArtDesigns.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> SubmitBuildingConstructionResults(BuildingConstructionDTO buildingConstructionDTO)
        {
            try
            {
                var s = new ResultsBuildingConstruction
                {
                    Id = Guid.NewGuid(),

                    Term = buildingConstructionDTO.Term,

                    StreamId = buildingConstructionDTO.StreamId,

                    ClassId = buildingConstructionDTO.ClassId,

                    StudentId = buildingConstructionDTO.StudentId,

                    Marks = buildingConstructionDTO.Marks,

                    Grade = buildingConstructionDTO.Grade,

                    Points = buildingConstructionDTO.Points,

                    CreateDate = DateTime.Now,

                    CreatedById = buildingConstructionDTO.CreatedById,

                };
                context.ResultsBuildingConstructions.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public Task<List<ExaminationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<ExaminationDTO> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExamResultsDTO>> GetAllResults()
        {
            var student = await context.ResultsAgricultures.ToListAsync();

            var students = new List<ExamResultsDTO>();

            foreach (var item in student)
            {
                var data = new ExamResultsDTO
                {
                    AgricsMarks = item.Marks,
                    AgricsPoints = item.Points,
                    AgricstureGrade = item.Grade,



                };

                students.Add(data);
            }
            return students;
        }

        public async Task<ExamResultsDTO> GetResultsByStudentId(Guid Id)
        {
            var agrics = await context.ResultsAgricultures.FindAsync(Id);
            var art = await context.ResultsArtDesigns.FindAsync(Id);
            var bio = await context.ResultsBiologies.FindAsync(Id);
            var buildConstr = await context.ResultsBuildingConstructions.FindAsync(Id);
            var BED = await context.ResultsBusinesses.FindAsync(Id);
            var Chem = await context.ResultsChemistries.FindAsync(Id);
            var Comp = await context.ResultsComputerStudies.FindAsync(Id);
            var CRE = await context.ResultsCREs.FindAsync(Id);
            var Eng = await context.ResultsEnglishes.FindAsync(Id);
            var French = await context.ResultsFrenches.FindAsync(Id);
            var Geog = await context.ResultsGeographies.FindAsync(Id);
            var German = await context.ResultsGermen.FindAsync(Id);
            var Histo = await context.ResultsHistories.FindAsync(Id);
            var Hscience = await context.ResultsHomeSciences.FindAsync(Id);
            var Kis = await context.ResultsKiswahilis.FindAsync(Id);
            var Math = await context.ResultsMaths.FindAsync(Id);
            var Music = await context.ResultsMusics.FindAsync(Id);
            var Phyc = await context.ResultsPhysics.FindAsync(Id);

            return new ExamResultsDTO
            {
                AgricsMarks = agrics.Marks,

                AgricsPoints = agrics.Points,

                AgricstureGrade = agrics.Grade,


                ArtDesignMarks = art.Marks,

                ArtDesignPoints = art.Points,

                ArtDesignGrade = art.Grade,


                BioMarks = bio.Marks,

                BioPoints = bio.Points,

                BioGrade = bio.Grade,


                BuildConsMarks = buildConstr.Marks,

                BuildConsPoints = buildConstr.Points,

                BuildConsGrade = buildConstr.Grade,


                BEDMarks = BED.Marks,

                BEDPoints = BED.Points,

                BEDGrade = BED.Grade,


                ChemMarks = Chem.Marks,

                ChemPoints = Chem.Points,

                ChemGrade = Chem.Grade,


                CompMarks = Comp.Marks,

                CompPoints = Comp.Points,

                CompGrade = Comp.Grade,


                CREMarks = CRE.Marks,

                CREPoints = CRE.Points,

                CREGrade = CRE.Grade,

            };
        }

    }
}

