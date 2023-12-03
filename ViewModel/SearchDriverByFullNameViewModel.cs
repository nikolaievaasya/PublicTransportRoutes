using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    class SearchDriverByFullNameViewModel : Core.ViewModel
    {
        public SearchDriverByFullNameViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

		private string _fullName;
		public string FullName
		{
			get { return _fullName; }
			set
			{
				_fullName = value;
				OnPropertyChanged(nameof(FullName));
			}
		}

		private RelayCommand _searchDriverByFullNameCommand;
		public RelayCommand SearchDriverByFullNameCommand
        {
			get
			{
				return _searchDriverByFullNameCommand ?? (_searchDriverByFullNameCommand = new RelayCommand(obj =>
				{

					SearchDriverByFullName();

				}, obj =>
				{
					return
						!string.IsNullOrEmpty(FullName);
				}));
			}
		}

        private void SearchDriverByFullName()
        {
			var searchResultCollection = new ObservableCollection<Driver>();

			foreach (var driver in DataStorageService.DriversCollection)
			{
				if (driver.FullName.Contains(FullName))
				{
					searchResultCollection.Add(driver);
				}
			}

			if (searchResultCollection.Count == 0)
			{
                MessageBox.Show("Driver not found!");
				return;
			}

			DataStorageService.SearchResultDriverByFullNameCollection = searchResultCollection;
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
