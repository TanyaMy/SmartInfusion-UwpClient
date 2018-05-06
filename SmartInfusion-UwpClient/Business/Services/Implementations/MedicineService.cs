using System.Threading.Tasks;
using SmartInfusion_UwpClient.Data.Api.APIs;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.Models;

namespace SmartInfusion_UwpClient.Business.Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRestApi _requestRestApi;

        public MedicineService(IMedicineRestApi requestRestApi)
        {
            _requestRestApi = requestRestApi;
        }

        public async Task<ResponseWrapper<MedicineDetailsModel>> GetMedicineDetailsAsync(int medicineId)
        {
            return await _requestRestApi.GetMedicineDetailsAsync(medicineId);
        }

        public async Task<ResponseWrapper<MedicineListViewModel>> GetMedicineListAsync()
        {
            return await _requestRestApi.GetMedicineListAsync();
        }

        public async Task<ResponseWrapper> AddMedicine(MedicineDetailsModel medicine)
        {
            return await _requestRestApi.AddMedicine(medicine);
        }
    }
}
