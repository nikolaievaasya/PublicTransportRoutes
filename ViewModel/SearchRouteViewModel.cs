using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchRouteViewModel : Core.ViewModel
    {
        public SearchRouteViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

		private int _indexRoute;
		public int IndexRoute
		{
			get { return _indexRoute; }
			set
			{
				_indexRoute = value;
				OnPropertyChanged(nameof(IndexRoute));
			}
		}

		private string _idRoute;
		public string IdRoute
		{
			get { return _idRoute; }
			set
			{
				_idRoute = value;
				OnPropertyChanged(nameof(IdRoute));
			}
		}

		private string _titleRoute;
		public string TitleRoute
		{
			get { return _titleRoute; }
			set
			{
				_titleRoute = value;
				OnPropertyChanged(nameof(TitleRoute));
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

		private ObservableCollection<Transport> _transportsCollection;
		public ObservableCollection<Transport> TransportsCollection
		{
			get { return _transportsCollection; }
			set
			{
				_transportsCollection = value;
				OnPropertyChanged(nameof(TransportsCollection));
			}
		}

		private RelayCommand _searchRouteCommand;
		public RelayCommand SearchRouteCommand
		{
			get
			{
				return _searchRouteCommand ?? (_searchRouteCommand = new RelayCommand(obj =>
				{

                    SearchRoute();

				}, obj =>
				{
					return
						IndexRoute != null;

                }));
			}
		}

        private void SearchRoute()
        {
			var searchResult = new RouteSearch();

			searchResult.IdRoute = DataStorageService.RoutesCollection[IndexRoute].Id;
			searchResult.TitleRoute = DataStorageService.RoutesCollection[IndexRoute].Title;

            IdRoute = searchResult.IdRoute.ToString();
            TitleRoute = searchResult.TitleRoute;

			var busStopDictionary = new Dictionary<int, BusStop>();

            foreach (var routePoint in DataStorageService.RoutePointsCollection)
			{
				if (routePoint.IdRoute == searchResult.IdRoute)
				{
					busStopDictionary.Add(routePoint.PointOrder, DataStorageService.BusStopsCollection.First(obj => obj.Id == routePoint.IdBusStop));
                }
			}

            if (busStopDictionary.Count == 0)
            {
                MessageBox.Show("The route has no bus stops!");
            }
			else
			{
				var busStopsCollection = busStopDictionary.ToList();

				foreach (var busStop in busStopsCollection)
				{
					searchResult.BusStops.Add(busStop.Value);
                }
			}

            BusStopsCollection = searchResult.BusStops;

            if (DataStorageService.TransportRoutesCollection == null)
            {
                MessageBox.Show("No routes tied to existing transports!");
                return;
            }

            foreach (var transportRoute in DataStorageService.TransportRoutesCollection)
			{
				if (transportRoute.IdRoute == searchResult.IdRoute)
				{
					var transport = DataStorageService.TransportCollection.First(obj => obj.Id == transportRoute.IdTransport);

					if (!searchResult.Transports.Contains(transport))
					{
						searchResult.Transports.Add(transport);
                    }
				}
			}

            if (searchResult.Transports == null)
            {
                MessageBox.Show("This route not used by any of the transports!");
            }

            TransportsCollection = searchResult.Transports;
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

	public class RouteSearch
	{
		public Guid IdRoute;
		public string TitleRoute;
		public ObservableCollection<BusStop> BusStops;
		public ObservableCollection<Transport> Transports;

		public RouteSearch()
		{
			BusStops = new ObservableCollection<BusStop>();
			Transports = new ObservableCollection<Transport>();
		}
	}
}
