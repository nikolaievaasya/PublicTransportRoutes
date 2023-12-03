using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    class HomeViewModel : Core.ViewModel
    {
        public HomeViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }
    }
}
