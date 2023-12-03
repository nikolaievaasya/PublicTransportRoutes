using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportRoutes.Services
{
    public interface IDataStorageService : INotifyPropertyChanged
    {
        //Здесь задаються общие переменные, колекции

        ObservableCollection<Driver> DriversCollection { get; set; }
        ObservableCollection<Transport> TransportCollection { get; set; }
        ObservableCollection<BusStop> BusStopsCollection { get; set; }
        ObservableCollection<Route> RoutesCollection { get; set; }
        ObservableCollection<RoutePoint> RoutePointsCollection { get; set; }
        ObservableCollection<TransportRoute> TransportRoutesCollection { get; set; }

        ObservableCollection<Driver> SearchResultDriverByFullNameCollection { get; set; }
        ObservableCollection<Driver> SearchResultDriverByPhoneCollection { get; set; }

        ObservableCollection<Transport> SearchResultTransportByTransportNumberCollection { get; set; }
        ObservableCollection<Transport> SearchResultTransportByDriverCollection { get; set; }

        public string[] TransportTypeComboBoxItems { get; set; }
        public string[] WeekdayComboBoxItems { get; set; }
    }

    public class DataStorageService : IDataStorageService
    {
        #region Data

        private ObservableCollection<Driver> _driversCollection;
        public ObservableCollection<Driver> DriversCollection
        {
            get { return _driversCollection; }
            set
            {
                _driversCollection = value;
                OnPropertyChanged(nameof(DriversCollection));
            }
        }

        private ObservableCollection<Transport> _transportCollection;
        public ObservableCollection<Transport> TransportCollection
        {
            get { return _transportCollection; }
            set
            {
                _transportCollection = value;
                OnPropertyChanged(nameof(TransportCollection));
            }
        }

        private ObservableCollection<BusStop> _busStopsCollection;
        public ObservableCollection<BusStop> BusStopsCollection
        {
            get { return _busStopsCollection; }
            set
            {
                _busStopsCollection = value;
                OnPropertyChanged(nameof(BusStopsCollection));
            }
        }

        private ObservableCollection<Route> _routesCollection;
        public ObservableCollection<Route> RoutesCollection
        {
            get { return _routesCollection; }
            set
            {
                _routesCollection = value;
                OnPropertyChanged(nameof(RoutesCollection));
            }
        }

        private ObservableCollection<RoutePoint> _routePointsCollection;
        public ObservableCollection<RoutePoint> RoutePointsCollection
        {
            get { return _routePointsCollection; }
            set
            {
                _routePointsCollection = value;
                OnPropertyChanged(nameof(RoutePointsCollection));
            }
        }

        private ObservableCollection<TransportRoute> _transportRoutesCollection;
        public ObservableCollection<TransportRoute> TransportRoutesCollection
        {
            get { return _transportRoutesCollection; }
            set
            {
                _transportRoutesCollection = value;
                OnPropertyChanged(nameof(TransportRoutesCollection));
            }
        }

        #endregion

        #region Search

        #region Driver

        private ObservableCollection<Driver> _searchResultDriverByFullNameCollection;
        public ObservableCollection<Driver> SearchResultDriverByFullNameCollection
        {
            get { return _searchResultDriverByFullNameCollection; }
            set
            {
                _searchResultDriverByFullNameCollection = value;
                OnPropertyChanged(nameof(SearchResultDriverByFullNameCollection));
            }
        }

        private ObservableCollection<Driver> _searchResultDriverByPhoneCollection;
        public ObservableCollection<Driver> SearchResultDriverByPhoneCollection
        {
            get { return _searchResultDriverByPhoneCollection; }
            set
            {
                _searchResultDriverByPhoneCollection = value;
                OnPropertyChanged(nameof(SearchResultDriverByPhoneCollection));
            }
        }

        #endregion

        #region Transport

        private ObservableCollection<Transport> _searchResultTransportByTransportNumberCollection;
        public ObservableCollection<Transport> SearchResultTransportByTransportNumberCollection
        {
            get { return _searchResultTransportByTransportNumberCollection; }
            set
            {
                _searchResultTransportByTransportNumberCollection = value;
                OnPropertyChanged(nameof(SearchResultTransportByTransportNumberCollection));
            }
        }

        private ObservableCollection<Transport> _searchResultTransportByDriverCollection;
        public ObservableCollection<Transport> SearchResultTransportByDriverCollection
        {
            get { return _searchResultTransportByDriverCollection; }
            set
            {
                _searchResultTransportByDriverCollection = value;
                OnPropertyChanged(nameof(SearchResultTransportByDriverCollection));
            }
        }

        #endregion

        #endregion

        private string[] _transportTypeComboBoxItems;
        public string[] TransportTypeComboBoxItems
        {
            get { return _transportTypeComboBoxItems; }
            set
            {
                _transportTypeComboBoxItems = value;
                OnPropertyChanged(nameof(TransportTypeComboBoxItems));
            }
        }

        private string[] _weekdayComboBoxItems;
        public string[] WeekdayComboBoxItems
        {
            get { return _weekdayComboBoxItems; }
            set
            {
                _weekdayComboBoxItems = value;
                OnPropertyChanged(nameof(WeekdayComboBoxItems));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
