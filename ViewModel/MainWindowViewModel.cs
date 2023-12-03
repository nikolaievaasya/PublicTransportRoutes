using System.Collections.ObjectModel;
using System.Windows;
using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;

namespace PublicTransportRoutes.ViewModel
{
    internal class MainWindowViewModel : Core.ViewModel
    {
        public MainWindowViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
            //Загрузка всех данных в DataStorageService
            DataStorageService.DriversCollection = JsonSerializationService.Deserialize<ObservableCollection<Driver>>("/Data/", "drivers.json");
            DataStorageService.TransportCollection = JsonSerializationService.Deserialize<ObservableCollection<Transport>>("/Data/", "transports.json");
            DataStorageService.BusStopsCollection = JsonSerializationService.Deserialize<ObservableCollection<BusStop>>("/Data/", "busStops.json");
            DataStorageService.RoutesCollection = JsonSerializationService.Deserialize<ObservableCollection<Route>>("/Data/", "routes.json");
            DataStorageService.RoutePointsCollection = JsonSerializationService.Deserialize<ObservableCollection<RoutePoint>>("/Data/", "routePoints.json");
            DataStorageService.TransportRoutesCollection = JsonSerializationService.Deserialize<ObservableCollection<TransportRoute>>("/Data/", "transportRoutes.json");

            DataStorageService.TransportTypeComboBoxItems = new string[]
            {
                "Bus", "Trolleybus"
            };
            DataStorageService.WeekdayComboBoxItems = new string[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };

            NavigationService.NavigateTo<HomeViewModel>();
        }

        #region Popup

        private bool isToogleButtonActive;
        public bool IsToogleButtonActive
        {
            get { return isToogleButtonActive; }
            set
            {
                isToogleButtonActive = value;
                OnPropertyChanged(nameof(IsToogleButtonActive));
            }
        }

        private Visibility popupVisability;
        public Visibility PopupVisability
        {
            get { return popupVisability; }
            set
            {
                popupVisability = value;
                OnPropertyChanged(nameof(PopupVisability));
            }
        }

        private bool isPopupOpen;
        public bool IsPopupOpen
        {
            get { return isPopupOpen; }
            set
            {
                isPopupOpen = value;
                OnPropertyChanged(nameof(IsPopupOpen));
            }
        }

        private RelayCommand collapseSideMenuPopupCommand;
        public RelayCommand CollapseSideMenuPopupCommand
        {
            get
            {
                return collapseSideMenuPopupCommand ?? (collapseSideMenuPopupCommand = new RelayCommand(obj =>
                {

                    PopupVisability = Visibility.Collapsed;
                    IsPopupOpen = false;

                }, obj => true));
            }
        }

        private RelayCommand _navigateToHomeView;
        public RelayCommand NavigateToHomeView
        {
            get
            {
                return _navigateToHomeView ?? (_navigateToHomeView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<HomeViewModel>();

                }, obj => true));
            }
        }

        private RelayCommand _navigateToAddView;
        public RelayCommand NavigateToAddView
        {
            get
            {
                return _navigateToAddView ?? (_navigateToAddView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<AddViewModel>();

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


        #endregion
    }
}
