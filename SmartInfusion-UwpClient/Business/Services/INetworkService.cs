namespace SmartInfusion_UwpClient.Business.Services
{
    public interface INetworkService
    {
        bool IsInternetConnectionAvailable { get; }
    }
}
