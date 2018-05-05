using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.Models;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Business.Services
{
    public interface IMedicineService
    {
        Task<ResponseWrapper<MedicineListViewModel>> GetMedicineListAsync();

        Task<ResponseWrapper<MedicineDetailsModel>> GetMedicineDetailsAsync(int medicineId);
    }
}
