using Manager.Data.DTOs.ExamResultsDTO;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ResultsModule
{
    public class ExamResultService : IExamResultService
    {
        private readonly StudentEntities context;
        public ExamResultService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<List<AgricultureDTO>> GetAllAgricultureResults()
        {
            try
            {
                var s = await context.ResultsAgricultures.ToListAsync();

                var k = new List<AgricultureDTO>();

                foreach (var item in s)
                {
                    var data = new AgricultureDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<ArtDesignDTO>> GetAllArtDesignResults()
        {
            try
            {
                var s = await context.ResultsArtDesigns.ToListAsync();

                var k = new List<ArtDesignDTO>();

                foreach (var item in s)
                {
                    var data = new ArtDesignDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<BiologyDTO>> GetAllBiologyResults()
        {
            try
            {
                var s = await context.ResultsBiologies.ToListAsync();

                var k = new List<BiologyDTO>();

                foreach (var item in s)
                {
                    var data = new BiologyDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<BuildingConstructionDTO>> GetAllBuildingConstructionResults()
        {
            try
            {
                var s = await context.ResultsBuildingConstructions.ToListAsync();

                var k = new List<BuildingConstructionDTO>();

                foreach (var item in s)
                {
                    var data = new BuildingConstructionDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<BusinessDTO>> GetAllBussinessManagementResults()
        {
            try
            {
                var s = await context.ResultsBusinesses.ToListAsync();

                var k = new List<BusinessDTO>();

                foreach (var item in s)
                {
                    var data = new BusinessDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<ChemistryDTO>> GetAllChemestryResults()
        {
            try
            {
                var s = await context.ResultsChemistries.ToListAsync();

                var k = new List<ChemistryDTO>();

                foreach (var item in s)
                {
                    var data = new ChemistryDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<ComputerDTO>> GetAllComputerStudiesResults()
        {
            try
            {
                var s = await context.ResultsComputerStudies.ToListAsync();

                var k = new List<ComputerDTO>();

                foreach (var item in s)
                {
                    var data = new ComputerDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<CREDTO>> GetAllCREResults()
        {
            try
            {
                var s = await context.ResultsCREs.ToListAsync();

                var k = new List<CREDTO>();

                foreach (var item in s)
                {
                    var data = new CREDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<EnglishDTO>> GetAllEnglishResults()
        {
            try
            {
                var s = await context.ResultsCREs.ToListAsync();

                var k = new List<EnglishDTO>();

                foreach (var item in s)
                {
                    var data = new EnglishDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<FrenchDTO>> GetAllFrenchResults()
        {
            try
            {
                var s = await context.ResultsFrenches.ToListAsync();

                var k = new List<FrenchDTO>();

                foreach (var item in s)
                {
                    var data = new FrenchDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<GeographyDTO>> GetAllGeographyResults()
        {
            try
            {
                var s = await context.ResultsGeographies.ToListAsync();

                var k = new List<GeographyDTO>();

                foreach (var item in s)
                {
                    var data = new GeographyDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<GermanDTO>> GetAllGermanResults()
        {
            try
            {
                var s = await context.ResultsGeographies.ToListAsync();

                var k = new List<GermanDTO>();

                foreach (var item in s)
                {
                    var data = new GermanDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<HistoryDTO>> GetAllHistoryGovernmentResults()
        {
            try
            {
                var s = await context.ResultsHistories.ToListAsync();

                var k = new List<HistoryDTO>();

                foreach (var item in s)
                {
                    var data = new HistoryDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<HomeScienceDTO>> GetAllHomeScienceResults()
        {
            try
            {
                var s = await context.ResultsHomeSciences.ToListAsync();

                var k = new List<HomeScienceDTO>();

                foreach (var item in s)
                {
                    var data = new HomeScienceDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<KiswahiliDTO>> GetAllKiswahiliResults()
        {
            try
            {
                var s = await context.ResultsKiswahilis.ToListAsync();

                var k = new List<KiswahiliDTO>();

                foreach (var item in s)
                {
                    var data = new KiswahiliDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<MathDTO>> GetAllMathematicsResults()
        {
            try
            {
                var s = await context.ResultsMaths.ToListAsync();

                var k = new List<MathDTO>();

                foreach (var item in s)
                {
                    var data = new MathDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<MusicDTO>> GetAllMusicResults()
        {
            try
            {
                var s = await context.ResultsMaths.ToListAsync();

                var k = new List<MusicDTO>();

                foreach (var item in s)
                {
                    var data = new MusicDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<PhysicsDTO>> GetAllPhysicsResults()
        {
            try
            {
                var s = await context.ResultsPhysics.ToListAsync();

                var k = new List<PhysicsDTO>();

                foreach (var item in s)
                {
                    var data = new PhysicsDTO
                    {
                        Id = item.Id,

                        Term = item.Term,

                        StreamId = item.StreamId,

                        ClassId = item.ClassId,

                        StudentId = item.StudentId,

                        Marks = item.Marks,

                        Grade = item.Grade,

                        Points = item.Points,

                        CreateDate = item.CreateDate,

                        CreatedById = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName,

                        ClassName = item.InstitutionClass.Name,

                        StreamName = item.InstitutionClass.Stream.Name,

                        Teacher = item.InstitutionClass.Employee.FirstName + " " + item.InstitutionClass.Employee.LastName,

                    };

                    k.Add(data);
                }

                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
