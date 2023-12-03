using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.Core
{
    public abstract class ViewModel : ObservableObject
    {
        protected INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        private IDataStorageService _dataStorageService;
        public IDataStorageService DataStorageService
        {
            get { return _dataStorageService; }
            set
            {
                _dataStorageService = value;
                OnPropertyChanged(nameof(DataStorageService));
            }
        }

        public ViewModel(INavigationService navigationService, IDataStorageService dataStorageService)
        {
            NavigationService = navigationService;
            DataStorageService = dataStorageService;
        }
    }
}
