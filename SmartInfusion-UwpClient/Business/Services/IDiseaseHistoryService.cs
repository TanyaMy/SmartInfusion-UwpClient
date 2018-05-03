using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using SmartInfusion_UwpClient.Presentation.Models;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Business.Services
{
    public interface IDiseaseHistoryService
    {
        Task<ResponseWrapper<DiseaseHistoryListModel>> GetDiseaseHistoryListAsync();

        Task<ResponseWrapper<DiseaseHistoryDetailsModel>> GetDiseaseHistoryDetailsAsync(int diseaseHistoryId);
    }
}
