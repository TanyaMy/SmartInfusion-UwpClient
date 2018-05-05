using Autofac;
using ReactiveUI;
using SmartInfusion_UwpClient.Presentation.ViewModels.DiseaseHistory;
using System;
using Windows.UI.Xaml;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SmartInfusion_UwpClient.Presentation.Views.MenuPage.DiseaseHistory
{
    public sealed partial class DiseaseHistoryListPage : IViewFor<DiseaseHistoryListViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(DiseaseHistoryListViewModel),
                typeof(DiseaseHistoryListPage), new PropertyMetadata(default(DiseaseHistoryListViewModel)));

        public DiseaseHistoryListPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<DiseaseHistoryListViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            //DiseaseHistoryMasterDetails.NoSelectionContent = new object();

            d(this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.Preloader.IsLoading));

            d(this.OneWayBind(ViewModel, vm => vm.DiseaseHistoryList, v => v.DiseaseHistoriesMasterDetails.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedItem, v => v.DiseaseHistoriesMasterDetails.SelectedItem));
            d(this.OneWayBind(ViewModel, vm => vm.MapListItemToDetails, v => v.DiseaseHistoriesMasterDetails.MapDetails));
            d(this.Bind(ViewModel, vm => vm.CurrentViewState, v => v.DiseaseHistoriesMasterDetails.ViewState));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DiseaseHistoryListViewModel)value;
        }

        public DiseaseHistoryListViewModel ViewModel
        {
            get => (DiseaseHistoryListViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
