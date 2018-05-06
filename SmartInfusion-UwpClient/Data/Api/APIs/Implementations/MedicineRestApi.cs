using SmartInfusion_UwpClient.Data.Api.Rest;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.Models;
using System;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Data.Api.APIs.Implementations
{
    public class MedicineRestApi : RestApiBase, IMedicineRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;

        public MedicineRestApi() : base(new Uri(BaseApiAddress))
        {
        }

        public async Task<ResponseWrapper<MedicineDetailsModel>> GetMedicineDetailsAsync(int medicineId)
        {
            var response = await Url($"medicine/getMedicineById/{medicineId}")
                                .GetAsync<ResponseWrapper<MedicineDetailsModel>>();
            return response;
        }

        public async Task<ResponseWrapper<MedicineListViewModel>> GetMedicineListAsync()
        {
            var response = await Url("medicine/getMedicines")
                                .GetAsync<ResponseWrapper<MedicineListViewModel>>();
            return response;
        }

        public Task<ResponseWrapper> AddMedicine(MedicineDetailsModel medicine)
        {
            return Url("medicine/addMedicine")
                                .FormUrlEncoded()
                                .Param(nameof(medicine.Title), medicine.Title)
                                .Param(nameof(medicine.Description), medicine.Description)
                                .PostAsync<ResponseWrapper>();
        }
    }
}