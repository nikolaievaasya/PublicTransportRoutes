using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchBusStopRoutesViewModel : Core.ViewModel
    {
        public SearchBusStopRoutesViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

		private int _indexBusStop;
		public int IndexBusStop
		{
			get { return _indexBusStop; }
			set
			{
                _indexBusStop = value;
				OnPropertyChanged(nameof(IndexBusStop));
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

		private RelayCommand _searchRoutesByBusStopCommand;
		public RelayCommand SearchRoutesByBusStopCommand
        {
			get
			{
				return _searchRoutesByBusStopCommand ?? (_searchRoutesByBusStopCommand = new RelayCommand(obj =>
				{

                    SearchRoutesByBusStop();

				}, obj =>
				{
					return
                        IndexBusStop != null;

                }));
			}
		}

        private void SearchRoutesByBusStop()
        {
			if (DataStorageService.RoutesCollection == null)
			{
				MessageBox.Show("No existent routes found!");
			}

			var searchResult = new ObservableCollection<Route>();

			var busStopId = DataStorageService.BusStopsCollection[IndexBusStop].Id;

			foreach (var point in DataStorageService.RoutePointsCollection)
			{
				if (point.IdBusStop == busStopId)
				{
					var route = DataStorageService.RoutesCollection.First(obj => obj.Id == point.IdRoute);

					if(!searchResult.Contains(route)) 
					{ 
						searchResult.Add(route);
					}
				}
            }

			if (searchResult.Count == 0)
			{
				MessageBox.Show("No routes found that use this bus stop!");
				RoutesCollection = new ObservableCollection<Route>();
				return;
            }

			RoutesCollection = searchResult;
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
