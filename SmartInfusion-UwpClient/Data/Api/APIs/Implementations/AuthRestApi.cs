using System;
using System.Threading.Tasks;
using SmartInfusion_UwpClient.Data.Api.Rest;
using SmartInfusion_UwpClient.Data.Api.APIs;
using SmartInfusion_UwpClient.Presentation.Models;
using SmartInfusion_UwpClient.Presentation.Models.Auth;

namespace SmartInfusion_UwpClient.Data.Api.APIs.Implementations
{
    public class AuthRestApi : RestApiBase, IAuthRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;

        public AuthRestApi() : base(new Uri(BaseApiAddress)) { }

        public Task<TokenModel> RetrieveTokenAsync(GetTokenModel model)
        {
            return Url("token")
                .FormUrlEncoded()
                .Param(nameof(model.Username), model.Username)
                .Param(nameof(model.Password), model.Password)
                .Param(nameof(model.RememberMe), model.RememberMe.ToString())
                .PostAsync<TokenModel>();
        }

        public Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync()
        {
            return Url("account/GetUserInfo")
                .GetAsync<ResponseWrapper<UserInfoModel>>();
        }
    }
}
