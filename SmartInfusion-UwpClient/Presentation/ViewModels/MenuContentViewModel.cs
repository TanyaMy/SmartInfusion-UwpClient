using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Presentation.Views.LoginPage;
using SmartInfusion_UwpClient.Presentation.Views.MenuPage;
using SmartInfusion_UwpClient.Presentation.Constants;
using SmartInfusion_UwpClient.Presentation.Views.MenuPage.DiseaseHistory;
using SmartInfusion_UwpClient.Presentation.Views.MenuPage.Medicine;

namespace SmartInfusion_UwpClient.Presentation.ViewModels
{
    public class MenuContentViewModel : ViewModelBase
    {
        private readonly IPreferencesService _preferencesService;

        private bool _isPaneOpened;
        private MenuItemViewModel _selectedMenuItem;
        private Type _currentPage;

        public MenuContentViewModel(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;

            OpenClosePaneCommand = ReactiveCommand.Create(OpenClosePaneCommandExecuted);

            this.ObservableForProperty(x => x.SelectedMenuItem)
                .Subscribe(args => OnSelectedMenuItemChanged(args.Value));

            FillMenuItems();
            SelectedMenuItem = MenuItems.First();
        }

        public ReactiveList<MenuItemViewModel> MenuItems { get; set; } = new ReactiveList<MenuItemViewModel>();

        public Type CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public MenuItemViewModel SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => this.RaiseAndSetIfChanged(ref _selectedMenuItem, value);
        }

        public bool IsPaneOpened
        {
            get => _isPaneOpened;
            set => this.RaiseAndSetIfChanged(ref _isPaneOpened, value);
        }

        public ReactiveCommand OpenClosePaneCommand { get; }


        public void OnSelectedMenuItemChanged(MenuItemViewModel item)
        {
            if (item.PageType != typeof(LoginPage))
            {
                CurrentPage = item.PageType;
            }
            else
            {
                var frame = (Window.Current.Content as Frame);
                frame?.Navigate(item.PageType);
                _preferencesService.Clear();
            }
            IsPaneOpened = false;
        }

        private void FillMenuItems()
        {
            string userRole = _preferencesService.UserInfo?.RoleName;

            MenuItems.Add(new MenuItemViewModel
            {
                DisplayName = "Home",
                Icon = "\xE80F",
                PageType = typeof(FirstMainPage)
            });

            if (userRole == RolesConstants.Doctor
                || userRole == RolesConstants.Administrator
                || userRole == RolesConstants.Nurse)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    Icon = "\xEE94",
                    DisplayName = "Medicines",
                    PageType = typeof(MedicineListPage)
                });
            };

            if (userRole == RolesConstants.Administrator)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    Icon = "\xECC8",
                    DisplayName = "Add medicines",
                    PageType = typeof(AddMedicinePage)
                });
            };

            if (userRole == RolesConstants.Doctor 
                || userRole == RolesConstants.Nurse)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    Icon = "\xE779",
                    DisplayName = "Disease Histories",
                    PageType = typeof(DiseaseHistoryListPage)
                });
            }
            else if (userRole == RolesConstants.Patient)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    DisplayName = "My Disease Histories",
                    Icon = "\xE133",
                    PageType = typeof(DiseaseHistoryListPage)
                });
            }

            MenuItems.Add(new MenuItemViewModel
            {
                DisplayName = "Logout",
                Icon = "\xE8F8",
                PageType = typeof(LoginPage)
            });
        }

        private void OpenClosePaneCommandExecuted()
        {
            IsPaneOpened = !IsPaneOpened;
        }
    }

    public class MenuItemViewModel : ReactiveObject
    {
        public string DisplayName { get; set; }

        public string Icon { get; set; }

        public Type PageType { get; set; }
    }
}
