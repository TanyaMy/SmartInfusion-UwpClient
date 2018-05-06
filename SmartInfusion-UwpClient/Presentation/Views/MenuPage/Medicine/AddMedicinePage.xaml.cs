using Autofac;
using ReactiveUI;
using SmartInfusion_UwpClient.Data.Entities.Medicine;
using SmartInfusion_UwpClient.Presentation.ViewModels.Medicine;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmartInfusion_UwpClient.Presentation.Views.MenuPage.Medicine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMedicinePage : IViewFor<AddMedicineViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
           DependencyProperty.Register("ViewModel", typeof(AddMedicineViewModel),
               typeof(AddMedicinePage), new PropertyMetadata(default(AddMedicineViewModel)));

        public AddMedicinePage()
        {
            this.InitializeComponent();
            ViewModel = App.Container.Resolve<AddMedicineViewModel>();
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AddMedicineViewModel)value;
        }

        public AddMedicineViewModel ViewModel
        {
            get => (AddMedicineViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        private void addMedicinebtn_Click(object sender, RoutedEventArgs e)
        {
            MedicineDetailsModel model = new MedicineDetailsModel
            {
                Title = this.MedicineTitle.Text.Trim(),
                Description = this.MedicineDesc.Text.Trim()
            };
            if (!string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Description))
            {
                ViewModel.AddMedicine(model);
            }
            ViewModel.GoToMenuContainerPage();
        }
    }
}
