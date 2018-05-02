using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReactiveUI;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Presentation.Models.Auth;
using SmartInfusion_UwpClient.Presentation.Views.MenuPage;

namespace SmartInfusion_UwpClient.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        private ReactiveCommand _signInCommand;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            SignInCommand = ReactiveCommand.CreateFromTask(SignIn);

            LoginModel = new LoginModel
            {
                Username = "doctor1@test.com",
                Password = "Test123!",
                RememberMe = true
            };
        }

        public LoginModel LoginModel { get; }

        public ReactiveCommand SignInCommand
        {
            get => _signInCommand;
            set => this.RaiseAndSetIfChanged(ref _signInCommand, value);
        }

        private async Task SignIn()
        {
            IsBusy = true;
            try
            {
                bool isSuccess = await _authenticationService.LoginAsync(LoginModel.Username, LoginModel.Password, LoginModel.RememberMe);
                if (isSuccess)
                {
                    GoToMenuContainerPage();
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void GoToMenuContainerPage()
        {
            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(MenuContentPage));
        }
    }
}
