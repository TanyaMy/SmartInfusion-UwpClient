using Microsoft.Toolkit.Uwp.UI.Controls;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using System;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Presentation.ViewModels.DiseaseHistory
{
    public class DiseaseHistoryListViewModel : ViewModelBase
    {
        private readonly IDiseaseHistoryService _diseaseHistoryService;
        private ReactiveList<DiseaseHistoryListItemModel> _diseaseHistoryList;
        private DiseaseHistoryListItemModel _selectedItem;

        public DiseaseHistoryListViewModel(IDiseaseHistoryService diseaseHistoryService)
        {
            _diseaseHistoryService = diseaseHistoryService;

            Init();
        }

        private async void Init()
        {
            await LoadDiseaseHistoryListAsync();
        }

        public Func<object, object> MapListItemToDetails => x => new DiseaseHistoryDetailsViewModel(x);

        public DiseaseHistoryListItemModel SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public MasterDetailsViewState CurrentViewState { get; set; }

        public ReactiveList<DiseaseHistoryListItemModel> DiseaseHistoryList
        {
            get => _diseaseHistoryList;
            set => this.RaiseAndSetIfChanged(ref _diseaseHistoryList, value);
        }

        private async Task LoadDiseaseHistoryListAsync()
        {
            OnIsInProgressChanges(true);
            try
            {
                var diseaseHistoryResponse = await _diseaseHistoryService.GetDiseaseHistoryListAsync();

                if (!diseaseHistoryResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(diseaseHistoryResponse.ErrorMessage)
                        ? "Load Disease History List Failed."
                        : diseaseHistoryResponse.ErrorMessage);
                    return;
                }

                DiseaseHistoryList =
                    new ReactiveList<DiseaseHistoryListItemModel>(diseaseHistoryResponse.Content.DiseaseHistoryList);
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
