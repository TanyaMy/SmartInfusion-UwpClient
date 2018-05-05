using Microsoft.Toolkit.Uwp.UI.Controls;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using System;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Presentation.ViewModels.Medicine
{
    public class MedicineListViewModel : ViewModelBase
    {
        private readonly IMedicineService _medicineService;
        private ReactiveList<MedicineListItemViewModel> _medicineList;
        private DiseaseHistoryListItemModel _selectedItem;

        public MedicineListViewModel(IMedicineService medicineService)
        {
            _medicineService = medicineService;

            Init();
        }

        private async void Init()
        {
            await LoadMedicineListAsync();
        }

        public Func<object, object> MapListItemToDetails => x => new MedicineDetailsViewModel(x);

        public DiseaseHistoryListItemModel SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public MasterDetailsViewState CurrentViewState { get; set; }

        public ReactiveList<MedicineListItemViewModel> MedicineList
        {
            get => _medicineList;
            set => this.RaiseAndSetIfChanged(ref _medicineList, value);
        }

        private async Task LoadMedicineListAsync()
        {
            OnIsInProgressChanges(true);
            try
            {
                var medicineResponse = await _medicineService.GetMedicineListAsync();

                if (!medicineResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(medicineResponse.ErrorMessage)
                        ? "Load Medicine List Failed."
                        : medicineResponse.ErrorMessage);
                    return;
                }

                MedicineList =
                    new ReactiveList<MedicineListItemViewModel>(medicineResponse.Content.Medicines);
            }
            catch
            {

            }
            finally
            {
                OnIsInProgressChanges(false);
            }
        }
    }
}
