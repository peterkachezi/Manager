using Manager.Data.DTOs.ExamResultsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ResultsModule
{
    public interface IExamResultService
    {
        Task<List<EnglishDTO>> GetAllEnglishResults();
        Task<List<MathDTO>> GetAllMathematicsResults();
        Task<List<KiswahiliDTO>> GetAllKiswahiliResults();
        Task<List<MusicDTO>> GetAllMusicResults();
        Task<List<ChemistryDTO>> GetAllChemestryResults();
        Task<List<PhysicsDTO>> GetAllPhysicsResults();
        Task<List<ArtDesignDTO>> GetAllArtDesignResults();
        Task<List<BuildingConstructionDTO>> GetAllBuildingConstructionResults();
        Task<List<BiologyDTO>> GetAllBiologyResults();
        Task<List<AgricultureDTO>> GetAllAgricultureResults();
        Task<List<ComputerDTO>> GetAllComputerStudiesResults();
        Task<List<BusinessDTO>> GetAllBussinessManagementResults();
        Task<List<CREDTO>> GetAllCREResults();
        Task<List<HomeScienceDTO>> GetAllHomeScienceResults();
        Task<List<FrenchDTO>> GetAllFrenchResults();
        Task<List<GermanDTO>> GetAllGermanResults();
        Task<List<GeographyDTO>> GetAllGeographyResults();
        Task<List<HistoryDTO>> GetAllHistoryGovernmentResults();

    }
}
