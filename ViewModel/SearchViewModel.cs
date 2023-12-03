using PublicTransportRoutes.Core;
using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    class SearchViewModel : Core.ViewModel
    {
        public SearchViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

		private RelayCommand _navigateToSearchDriverView;
		public RelayCommand NavigateToSearchDriverView
		{
			get
			{
				return _navigateToSearchDriverView ?? (_navigateToSearchDriverView = new RelayCommand(obj =>
				{

					NavigationService.NavigateTo<SearchDriverViewModel>();

				}, obj => true));
			}
		}

        private RelayCommand _navigateToSearchTransportView;
        public RelayCommand NavigateToSearchTransportView
        {
            get
            {
                return _navigateToSearchTransportView ?? (_navigateToSearchTransportView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchTransportViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToSearchRouteView;
        public RelayCommand NavigateToSearchRouteView
        {
            get
            {
                return _navigateToSearchRouteView ?? (_navigateToSearchRouteView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchRouteViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToSearchBusStopRoutesView;
        public RelayCommand NavigateToSearchBusStopRoutesView
        {
            get
            {
                return _navigateToSearchBusStopRoutesView ?? (_navigateToSearchBusStopRoutesView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchBusStopRoutesViewModel>();

                }, obj => true));
            }
        }
    }
}
