using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchTransportByTransportNumberViewModel : Core.ViewModel
    {
        public SearchTransportByTransportNumberViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private string _transportNumber;
        public string TransportNumber
        {
            get { return _transportNumber; }
            set
            {
                _transportNumber = value;
                OnPropertyChanged(nameof(TransportNumber));
            }
        }

        private RelayCommand _searchTransportByTransportNumberCommand;
        public RelayCommand SearchTransportByTransportNumberCommand
        {
            get
            {
                return _searchTransportByTransportNumberCommand ?? (_searchTransportByTransportNumberCommand = new RelayCommand(obj =>
                {

                    SearchTransportByTransportNumber();

                }, obj =>
                {
                    return
                        !string.IsNullOrEmpty(TransportNumber) &&
                        (TransportNumber.Length > 0 && TransportNumber.Length <= 8) &&
                        DataStorageService.TransportCollection != null;
                }));
            }
        }

        private void SearchTransportByTransportNumber()
        {
            var searchResultCollection = new ObservableCollection<Transport>();

            foreach (var transport in DataStorageService.TransportCollection)
            {
                if (transport.TransportNumber.Contains(TransportNumber))
                {
                    searchResultCollection.Add(transport);
                }
            }

            if (searchResultCollection.Count == 0)
            {
                MessageBox.Show("Transport not found!");
                return;
            }

            DataStorageService.SearchResultTransportByTransportNumberCollection = searchResultCollection;
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
