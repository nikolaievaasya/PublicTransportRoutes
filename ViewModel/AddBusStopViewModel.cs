using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    internal class AddBusStopViewModel : Core.ViewModel
    {
        public AddBusStopViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private RelayCommand _addBusStopCommand;
		public RelayCommand AddBusStopCommand
		{
			get
			{
				return _addBusStopCommand ?? (_addBusStopCommand = new RelayCommand(obj =>
				{

					AddBusStop();

				}, obj => {
					return
						!string.IsNullOrEmpty(Title);
				}));
			}
		}

        private void AddBusStop()
        {
            if (DataStorageService.BusStopsCollection == null)
                DataStorageService.BusStopsCollection = new ObservableCollection<BusStop>() { new BusStop(Title) };

			else
			{
                bool busStopAlreadyExisted = false;

				foreach (var busStop in DataStorageService.BusStopsCollection)
				{
					if (busStop.Title == Title)
					{
						busStopAlreadyExisted = true;
						break;
					}
				}

				if (busStopAlreadyExisted)
				{
                    MessageBox.Show("Bus stop already registered!");
                    return;
                }
                
				DataStorageService.BusStopsCollection.Add(new BusStop(Title));
            }

            JsonSerializationService.Serialize(DataStorageService.BusStopsCollection, "/Data/", "busStops.json");

            MessageBox.Show("Bus stop successfully registered!");
        }
    }
}
