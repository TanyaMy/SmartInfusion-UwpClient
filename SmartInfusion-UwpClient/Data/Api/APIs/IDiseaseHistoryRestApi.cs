using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using SmartInfusion_UwpClient.Presentation.Models;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Data.Api.APIs
{
    public interface IDiseaseHistoryRestApi
    {
        Task<ResponseWrapper<DiseaseHistoryListModel>> GetDiseaseHisoryListAsync();

        Task<ResponseWrapper<DiseaseHistoryDetailsModel>> GetDiseaseHisoryDetailsAsync(int diseaseHistoryId);
    }
}
