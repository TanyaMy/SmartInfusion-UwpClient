using System.Threading.Tasks;
using SmartInfusion_UwpClient.Data.Api.APIs;
using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using SmartInfusion_UwpClient.Presentation.Models;

namespace SmartInfusion_UwpClient.Business.Services.Implementations
{
    public class DiseaseHistoryService : IDiseaseHistoryService
    {
        private readonly IDiseaseHistoryRestApi _requestRestApi;

        public DiseaseHistoryService(IDiseaseHistoryRestApi requestRestApi)
        {
            _requestRestApi = requestRestApi;
        }

        public async Task<ResponseWrapper<DiseaseHistoryDetailsModel>> GetDiseaseHistoryDetailsAsync(int diseaseHistoryId)
        {
            return await _requestRestApi.GetDiseaseHisoryDetailsAsync(diseaseHistoryId);
        }

        public async Task<ResponseWrapper<DiseaseHistoryListModel>> GetDiseaseHistoryListAsync()
        {
            return await _requestRestApi.GetDiseaseHisoryListAsync();
        }
    }
}
