using PublicTransportRoutes.Core;
using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    class SearchDriverViewModel : Core.ViewModel
    {
        public SearchDriverViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private RelayCommand _navigateToSearchDriverByFullNameView;
        public RelayCommand NavigateToSearchDriverByFullNameView
        {
            get
            {
                return _navigateToSearchDriverByFullNameView ?? (_navigateToSearchDriverByFullNameView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchDriverByFullNameViewModel>();

                }, obj => true));
            }
        }


        private RelayCommand _navigateToSearchDriverByPhoneView;
        public RelayCommand NavigateToSearchDriverByPhoneView
        {
            get
            {
                return _navigateToSearchDriverByPhoneView ?? (_navigateToSearchDriverByPhoneView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchDriverByPhoneViewModel>();

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
