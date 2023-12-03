using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchDriverByPhoneViewModel : Core.ViewModel
    {
        public SearchDriverByPhoneViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private RelayCommand _searchDriverByPhoneCommand;
        public RelayCommand SearchDriverByPhoneCommand
        {
            get
            {
                return _searchDriverByPhoneCommand ?? (_searchDriverByPhoneCommand = new RelayCommand(obj =>
                {

                    SearchDriverByFullName();

                }, obj =>
                {
                    return
                        !string.IsNullOrEmpty(Phone) &&
                        Phone.Length <= 12;
                }));
            }
        }

        private void SearchDriverByFullName()
        {
            var searchResultCollection = new ObservableCollection<Driver>();

            foreach (var driver in DataStorageService.DriversCollection)
            {
                if (driver.Phone.Contains(Phone))
                {
                    searchResultCollection.Add(driver);
                }
            }

            if (searchResultCollection.Count == 0)
            {
                MessageBox.Show("Driver not found!");
                return;
            }

            DataStorageService.SearchResultDriverByPhoneCollection = searchResultCollection;
        }

        private RelayCommand _navigateToDriverSearchView;
        public RelayCommand NavigateToDriverSearchView
        {
            get
            {
                return _navigateToDriverSearchView ?? (_navigateToDriverSearchView = new RelayCommand(obj =>
                {

                    NavigationService.NavigateTo<SearchDriverViewModel>();

                }, obj => true));
            }
        }
    }
}
