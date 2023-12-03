using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    internal class AddRouteViewModel : Core.ViewModel
    {
        public AddRouteViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
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


		private RelayCommand _addRouteCommand;
		public RelayCommand AddRouteCommand
		{
			get
			{
				return _addRouteCommand ?? (_addRouteCommand = new RelayCommand(obj =>
				{

                    AddRoute();

				}, obj =>
				{
					return
						!string.IsNullOrEmpty(Title);
				}));
			}
        }

        private void AddRoute()
        {
            if (DataStorageService.RoutesCollection == null)
                DataStorageService.RoutesCollection = new ObservableCollection<Route>() { new Route(Title) };

            else
            {
                bool routeAlreadyExisted = false;

                foreach (var route in DataStorageService.RoutesCollection)
                {
                    if (route.Title == Title)
                    {
                        routeAlreadyExisted = true;
                        break;
                    }
                }

                if (routeAlreadyExisted)
                {
                    MessageBox.Show("Route already registered!");
                    return;
                }

                DataStorageService.RoutesCollection.Add(new Route(Title));
            }

            JsonSerializationService.Serialize(DataStorageService.RoutesCollection, "/Data/", "routes.json");

            MessageBox.Show("Route successfully registered!");
        }
    }
}
