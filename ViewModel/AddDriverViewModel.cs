using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
	internal class AddDriverViewModel : Core.ViewModel
	{
        public AddDriverViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : 
			base(navigationService, dataStorageService)
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

		private RelayCommand _addDriverCommand;

        public RelayCommand AddDriverCommand
		{
			get
			{
				return _addDriverCommand ?? (_addDriverCommand = new RelayCommand(obj =>
				{

					AddDriver();

				}, obj =>
				{
					return
						!string.IsNullOrEmpty(FullName) &&
						!string.IsNullOrEmpty(Phone) &&
						Phone.Length == 12;
				}));
			}
		}

		private void AddDriver()
		{

			if (DataStorageService.DriversCollection == null) DataStorageService.DriversCollection = new ObservableCollection<Driver>() { new Driver(FullName, Phone) };

			else
			{
				bool driverAlreadyExisted = false;

                foreach (var driver in DataStorageService.DriversCollection)
                {
                    if (driver.FullName == FullName)

                        driverAlreadyExisted = true;
                }

                if (driverAlreadyExisted)
				{
                    MessageBox.Show("Driver already registered!");
                    return;
                }
                    
				DataStorageService.DriversCollection.Add(new Driver(FullName, Phone));
			}

			JsonSerializationService.Serialize(DataStorageService.DriversCollection, "/Data/", "drivers.json");
            MessageBox.Show("Driver successfully registered!");
        }
	}
}
