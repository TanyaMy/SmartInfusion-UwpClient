using Autofac;
using ReactiveUI;
using SmartInfusion_UwpClient.Presentation.ViewModels.Medicine;
using System;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartInfusion_UwpClient.Presentation.Views.MenuPage.Medicine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MedicineListPage : IViewFor<MedicineListViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(MedicineListViewModel),
                typeof(MedicineListPage), new PropertyMetadata(default(MedicineListViewModel)));

        public MedicineListPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<MedicineListViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            //MedicinesMasterDetails.NoSelectionContent = new object();

            d(this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.Preloader.IsLoading));

            d(this.OneWayBind(ViewModel, vm => vm.MedicineList, v => v.MedicinesMasterDetails.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedItem, v => v.MedicinesMasterDetails.SelectedItem));
            d(this.OneWayBind(ViewModel, vm => vm.MapListItemToDetails, v => v.MedicinesMasterDetails.MapDetails));
            d(this.Bind(ViewModel, vm => vm.CurrentViewState, v => v.MedicinesMasterDetails.ViewState));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MedicineListViewModel)value;
        }

        public MedicineListViewModel ViewModel
        {
            get => (MedicineListViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
