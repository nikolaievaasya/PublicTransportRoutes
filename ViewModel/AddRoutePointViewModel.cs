using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    internal class AddRoutePointViewModel : Core.ViewModel
    {
        public AddRoutePointViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
			PointOrder = 1;
        }

		private int _pointOrder;
		public int PointOrder
		{
			get { return _pointOrder; }
			set
			{
				_pointOrder = value;
				OnPropertyChanged(nameof(PointOrder));
			}
		}


		private int _routeComboBoxIndex;
		public int RouteComboBoxIndex
		{
			get { return _routeComboBoxIndex; }
			set
			{
				_routeComboBoxIndex = value;
				OnPropertyChanged(nameof(RouteComboBoxIndex));
			}
		}


		private int _busStopComboBoxIndex;
		public int BusStopComboBoxIndex
		{
			get { return _busStopComboBoxIndex; }
			set
			{
				_busStopComboBoxIndex = value;
				OnPropertyChanged(nameof(BusStopComboBoxIndex));
			}
		}


		private RelayCommand _addRoutePointCommand;
		public RelayCommand AddRoutePointCommand
		{
			get
			{
				return _addRoutePointCommand ?? (_addRoutePointCommand = new RelayCommand(obj =>
				{

					AddRoutePoint();

				}, obj => true));
			}
		}

        private void AddRoutePoint()
        {
            if (DataStorageService.RoutePointsCollection == null)
                DataStorageService.RoutePointsCollection = new ObservableCollection<RoutePoint>() 
				{ 
					new RoutePoint(DataStorageService.RoutesCollection[RouteComboBoxIndex].Id,
								   DataStorageService.BusStopsCollection[BusStopComboBoxIndex].Id,
								   PointOrder) 
				};

            else
            {
                bool routePointAlreadyExisted = false;

                foreach (var routePoint in DataStorageService.RoutePointsCollection)
                {
                    if (routePoint.PointOrder == PointOrder)
                    {
                        routePointAlreadyExisted = true;
                        break;
                    }
                }

                if (routePointAlreadyExisted)
                {
                    MessageBox.Show("Route point with this order already existed!");
                    return;
                }

				DataStorageService.RoutePointsCollection.Add(
					new RoutePoint(DataStorageService.RoutesCollection[RouteComboBoxIndex].Id,
                                   DataStorageService.BusStopsCollection[BusStopComboBoxIndex].Id,
                                   PointOrder));
            }

            JsonSerializationService.Serialize(DataStorageService.RoutePointsCollection, "/Data/", "routePoints.json");

            MessageBox.Show("Route point successfully registered!");
        }


		private RelayCommand _spinnerButtonUpCommand;
		public RelayCommand SpinnerButtonUpCommand
		{
			get
			{
				return _spinnerButtonUpCommand ?? (_spinnerButtonUpCommand = new RelayCommand(obj =>
				{

						PointOrder++;

				}, obj => 
				{
					return
						PointOrder < 999;
				}));
			}
		}

        private RelayCommand _spinnerButtonDownCommand;
        public RelayCommand SpinnerButtonDownCommand
        {
            get
            {
                return _spinnerButtonDownCommand ?? (_spinnerButtonDownCommand = new RelayCommand(obj =>
                {

                        PointOrder--;

                }, obj =>
				{
					return
						PointOrder > 1;
				}));
            }
        }

    }
}
