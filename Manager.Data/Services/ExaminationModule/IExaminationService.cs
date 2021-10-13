using Manager.Data.DTOs.ExaminationModule;
using Manager.Data.DTOs.ExamResultsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ExaminationModule
{
    public interface IExaminationService
    {
        Task<List<ExaminationDTO>> GetAll();
        Task<List<TestDTO>> Test();
        Task<ExaminationDTO> GetById(Guid Id);
        Task<bool> Update(ExaminationDTO examinationDTO);
        Task<bool> SubmitEnglishResults(EnglishDTO englishDTO);
        Task<bool> SubmitKiswahiliResults(KiswahiliDTO kiswahiliDTO); 
        Task<bool> SubmitMathematicsResults(MathDTO mathDTO);
        Task<bool> SubmitHistoryResults(HistoryDTO historyDTO);
        Task<bool> SubmitGeographyResults(GeographyDTO geographyDTO);
        Task<bool> SubmitCREResults(CREDTO cREDTO);
        Task<bool> SubmitComputerResults(ComputerDTO computerDTO);
        Task<bool> SubmitAgricultureResults(AgricultureDTO agricultureDTO);
        Task<bool> SubmitBusinessResults(BusinessDTO businessDTO);
        Task<bool> SubmitFrenchResults(FrenchDTO frenchDTO);
        Task<bool> SubmitGermanResults(GermanDTO germanDTO);
        Task<bool> SubmitHomescienceResults(HomeScienceDTO homeScienceDTO);
        Task<bool> SubmitBiologyResults(BiologyDTO biologyDTO);
        Task<bool> SubmitMusicResults(MusicDTO musicDTO);
        Task<bool> SubmitChemestryResults(ChemistryDTO chemistryDTO);
        Task<bool> SubmitPhysicsResults(PhysicsDTO physicsDTO);
        Task<bool> SubmitArtDesignResults(ArtDesignDTO artDesignDTO);
        Task<bool> SubmitBuildingConstructionResults(BuildingConstructionDTO buildingConstructionDTO);
    }
}
