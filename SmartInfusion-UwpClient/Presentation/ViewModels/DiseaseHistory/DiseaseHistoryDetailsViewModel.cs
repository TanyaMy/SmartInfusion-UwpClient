using Autofac;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Data.Entities.DiseaseHistory;
using System.Threading.Tasks;

namespace SmartInfusion_UwpClient.Presentation.ViewModels.DiseaseHistory
{
    public class DiseaseHistoryDetailsViewModel : ViewModelBase
    {
        private readonly IDiseaseHistoryService _diseaseHistoryService;

        private readonly DiseaseHistoryListItemModel _listItem;
        private DiseaseHistoryDetailsModel _detailsModel;

        public DiseaseHistoryDetailsViewModel(object diseaseHistoryListItem)
        {
            _listItem = diseaseHistoryListItem as DiseaseHistoryListItemModel;
            _diseaseHistoryService = App.Container.Resolve<IDiseaseHistoryService>();

            Init();
        }

        public DiseaseHistoryDetailsModel Details
        {
            get => _detailsModel;
            set => this.RaiseAndSetIfChanged(ref _detailsModel, value);
        }
      
        private async void Init()
        {
            Details = await LoadDiseaseHistoryDetailsAsync();
        }

        private async Task<DiseaseHistoryDetailsModel> LoadDiseaseHistoryDetailsAsync()
        {
            DiseaseHistoryDetailsModel result = null;
            OnIsInProgressChanges(true);

            try
            {
                var diseaseHistoryResponse = await _diseaseHistoryService.GetDiseaseHistoryDetailsAsync(_listItem.Id);

                if (!diseaseHistoryResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(diseaseHistoryResponse.ErrorMessage)
                        ? "Load Disease History Request Failed."
                        : diseaseHistoryResponse.ErrorMessage);
                    return null;
                }

                result = diseaseHistoryResponse.Content;
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
