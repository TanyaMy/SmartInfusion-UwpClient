using System;
using SmartInfusion_UwpClient.Presentation.Models.Auth;

namespace SmartInfusion_UwpClient.Business.Services
{
    public interface IPreferencesService
    {
        DateTime LastUpdateTokenTime { get; set; }

        TokenModel TokenInfo { get; set; }

        UserInfoModel UserInfo { get; set; }

        string AccessToken { get; }

        bool IsLoggedIn { get; }

        void Clear();
    }
}