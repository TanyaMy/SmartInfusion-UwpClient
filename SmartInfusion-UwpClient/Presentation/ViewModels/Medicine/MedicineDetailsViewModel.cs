using Autofac;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Presentation.ViewModels.Medicine
{
    public class MedicineDetailsViewModel : ViewModelBase
    {
        private readonly IMedicineService _medicineService;

        private readonly MedicineListItemViewModel _listItem;
        private MedicineDetailsModel _detailsModel;

        public MedicineDetailsViewModel(object medicineListItem)
        {
            _listItem = medicineListItem as MedicineListItemViewModel;
            _medicineService = App.Container.Resolve<IMedicineService>();

            Init();
        }

        public MedicineDetailsModel Details
        {
            get => _detailsModel;
            set => this.RaiseAndSetIfChanged(ref _detailsModel, value);
        }
      
        private async void Init()
        {
            Details = await LoadMedicineDetailsAsync();
        }

        private async Task<MedicineDetailsModel> LoadMedicineDetailsAsync()
        {
            MedicineDetailsModel result = null;
            OnIsInProgressChanges(true);

            try
            {
                var medicineResponse = await _medicineService.GetMedicineDetailsAsync(_listItem.Id);

                if (!medicineResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(medicineResponse.ErrorMessage)
                        ? "Load Medicine Request Failed."
                        : medicineResponse.ErrorMessage);
                    return null;
                }

                result = medicineResponse.Content;
            }
            catch
            {
                //TODO: Do nothing 
            }
            finally
            {
                OnIsInProgressChanges(false);
            }

            return result;
        }
    }
}
