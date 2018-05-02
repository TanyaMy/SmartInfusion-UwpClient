using System.Threading.Tasks;
using SmartInfusion_UwpClient.Data.Api.APIs.Implementations;
using SmartInfusion_UwpClient.Presentation.Models;
using SmartInfusion_UwpClient.Presentation.Models.Auth;

namespace SmartInfusion_UwpClient.Data.Api.APIs
{
    public interface IAuthRestApi
    {
        Task<TokenModel> RetrieveTokenAsync(GetTokenModel model);

        Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync();
    }
}
