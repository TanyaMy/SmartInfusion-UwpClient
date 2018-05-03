using SmartInfusion_UwpClient.Data.Api.Rest;
using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using SmartInfusion_UwpClient.Presentation.Models;
using System;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Data.Api.APIs.Implementations
{
    public class DiseaseHistoryRestApi : RestApiBase, IDiseaseHistoryRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;

        public DiseaseHistoryRestApi() : base(new Uri(BaseApiAddress))
        {
        }

        public async Task<ResponseWrapper<DiseaseHistoryDetailsModel>> GetDiseaseHisoryDetailsAsync(int diseaseHistoryId)
        {
            var response = await Url($"diseaseHistory/getDiseaseHistoryDetails/{diseaseHistoryId}")
               .GetAsync<ResponseWrapper<DiseaseHistoryDetailsModel>>();
            return response;
        }

        public async Task<ResponseWrapper<DiseaseHistoryListModel>> GetDiseaseHisoryListAsync()
        {
            var response = await Url("diseaseHistory/getDiseaseHistories")
                   .GetAsync<ResponseWrapper<DiseaseHistoryListModel>>();
            return response;
        }
    }
}
