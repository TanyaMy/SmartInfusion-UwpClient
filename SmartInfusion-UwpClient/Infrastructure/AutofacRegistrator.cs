using Autofac;
using SmartInfusion_UwpClient.Business.Services;
using SmartInfusion_UwpClient.Business.Services.Implementations;
using SmartInfusion_UwpClient.Data.Api.APIs;
using SmartInfusion_UwpClient.Data.Api.APIs.Implementations;
using SmartInfusion_UwpClient.Presentation.ViewModels;

namespace SmartInfusion_UwpClient.Infrastructure
{
    public static class AutofacRegistrator
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterApis(builder);
            RegisterViewModels(builder);
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MenuContentViewModel>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<LoginViewModel>().AsSelf().AsImplementedInterfaces();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<PreferencesService>().As<IPreferencesService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<NetworkService>().As<INetworkService>();
        }

        private static void RegisterApis(ContainerBuilder builder)
        {
            builder.RegisterType<AuthRestApi>().As<IAuthRestApi>();
        }
    }
}
