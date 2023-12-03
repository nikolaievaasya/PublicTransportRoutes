using PublicTransportRoutes.Core;
using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    class SearchTransportViewModel : Core.ViewModel
    {
        public SearchTransportViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private RelayCommand _navigateToSearchTransportByTransportNumberView;
        public RelayCommand NavigateToSearchTransportByTransportNumberView
        {
            get
            {
                return _navigateToSearchTransportByTransportNumberView ?? (_navigateToSearchTransportByTransportNumberView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchTransportByTransportNumberViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToSearchTransportByDriverView;
        public RelayCommand NavigateToSearchTransportByDriverView
        {
            get
            {
                return _navigateToSearchTransportByDriverView ?? (_navigateToSearchTransportByDriverView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchTransportByDriverViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToSearchView;
        public RelayCommand NavigateToSearchView
        {
            get
            {
                return _navigateToSearchView ?? (_navigateToSearchView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchViewModel>();

                }, obj => true));
            }
        }
    }
}
