using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.Models;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Data.Api.APIs
{
    public interface IMedicineRestApi
    {
        Task<ResponseWrapper<MedicineListViewModel>> GetMedicineListAsync();

        Task<ResponseWrapper<MedicineDetailsModel>> GetMedicineDetailsAsync(int medicineId);

        Task<ResponseWrapper> AddMedicine(MedicineDetailsModel medicine);
    }
}
