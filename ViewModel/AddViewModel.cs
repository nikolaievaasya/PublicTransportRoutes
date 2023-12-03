using PublicTransportRoutes.Core;
using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    class AddViewModel : Core.ViewModel
    {
        public AddViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private RelayCommand _navigateToAddDriverView;
        public RelayCommand NavigateToAddDriverView
        {
            get
            {
                return _navigateToAddDriverView ?? (_navigateToAddDriverView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddDriverViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddTransportView;
        public RelayCommand NavigateToAddTransportView
        {
            get
            {
                return _navigateToAddTransportView ?? (_navigateToAddTransportView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddTransportViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddBusStopView;
        public RelayCommand NavigateToAddBusStopView
        {
            get
            {
                return _navigateToAddBusStopView ?? (_navigateToAddBusStopView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddBusStopViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddRouteView;
        public RelayCommand NavigateToAddRouteView
        {
            get
            {
                return _navigateToAddRouteView ?? (_navigateToAddRouteView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddRouteViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddRoutePointView;
        public RelayCommand NavigateToAddRoutePointView
        {
            get
            {
                return _navigateToAddRoutePointView ?? (_navigateToAddRoutePointView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddRoutePointViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddTransportRouteView;
        public RelayCommand NavigateToAddTransportRouteView
        {
            get
            {
                return _navigateToAddTransportRouteView ?? (_navigateToAddTransportRouteView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddTransportRouteViewModel>();

                }, obj => true));
            }
        }
    }
}
