using System.Threading.Tasks;
using SmartInfusion_UwpClient.Presentation.Models.Auth;

namespace SmartInfusion_UwpClient.Business.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password, bool rememberMe);

        Task<UserInfoModel> UpdateUserInfoAsync();

        void Logout();
    }
}
