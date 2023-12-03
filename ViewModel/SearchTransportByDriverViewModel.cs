using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchTransportByDriverViewModel : Core.ViewModel
    {
        public SearchTransportByDriverViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private int _idDriver;
        public int IdDriver
        {
            get { return _idDriver; }
            set
            {
                _idDriver = value;
                OnPropertyChanged(nameof(IdDriver));
            }
        }

        private RelayCommand _searchTransportByDriverCommand;
        public RelayCommand SearchTransportByDriverCommand
        {
            get
            {
                return _searchTransportByDriverCommand ?? (_searchTransportByDriverCommand = new RelayCommand(obj =>
                {

                    SearchTransportByDriver();

                }, obj =>
                {
                    return
                        IdDriver != null;
                }));
            }
        }

        private void SearchTransportByDriver()
        {
            var searchResultCollection = new ObservableCollection<Transport>();

            var driverId = DataStorageService.DriversCollection[IdDriver].Id;

            foreach (var transport in DataStorageService.TransportCollection)
            {
                if (transport.IdDriver == driverId)
                {
                    searchResultCollection.Add(transport);
                }
            }

            if (searchResultCollection.Count == 0)
            {
                MessageBox.Show("Transport not found!");
                return;
            }

            DataStorageService.SearchResultTransportByDriverCollection = searchResultCollection;
        }

        private RelayCommand _navigateToSearchTransportView;
        public RelayCommand NavigateToSearchTransportView
        {
            get
            {
                return _navigateToSearchTransportView ?? (_navigateToSearchTransportView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchTransportViewModel>();

                }, obj => true));
            }
        }
    }
}
