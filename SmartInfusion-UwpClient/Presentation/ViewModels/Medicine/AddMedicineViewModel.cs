using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.Views.MenuPage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SmartInfusion_UwpClient.Presentation.ViewModels.Medicine
{
    public class AddMedicineViewModel : ViewModelBase
    {
        private readonly IMedicineService _medicineService;

        public AddMedicineViewModel(IMedicineService medService)
        {
            _medicineService = medService;
        }

        public void GoToMenuContainerPage()
        {
            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(MenuContentPage), "MedicineListPage");
        }

        public void AddMedicine(MedicineDetailsModel medicine)
        {
            _medicineService.AddMedicine(medicine);
        }

    }
}
