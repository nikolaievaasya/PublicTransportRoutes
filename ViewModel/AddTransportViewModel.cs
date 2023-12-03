using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    internal class AddTransportViewModel : Core.ViewModel
    {
        public AddTransportViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
        }

        //  Выбраный индекс из ComboBox'а с ФИО водителей.
        //  По нему мы потом получим Guid водителя для добавления его в соответсвующее поле нового обьекта класса Transport.
        private int _indexDriver;
        public int IndexDriver
        {
            get { return _indexDriver; ; }
            set
            {
                _indexDriver = value;
                OnPropertyChanged(nameof(IndexDriver));
            }
        }

        //  Тип транспорта, - Автобус, Тролейбус и тд.
        private string _transportType;
        public string TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;
                OnPropertyChanged(nameof(TransportType));
            }
        }

        //  Количество мест в транспорте.
        private int _numberOfSeats;
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set
            {
                _numberOfSeats = value;
                OnPropertyChanged(nameof(NumberOfSeats));
            }
        }

        //  Номерной знак автомобиля.
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

        //  Команда для Bind привязки
        private RelayCommand _addTransportCommand;
        public RelayCommand AddTransportCommand
        {
            get
            {
                return _addTransportCommand ?? (_addTransportCommand = new RelayCommand(obj =>
                {

                    AddTransport();

                }, obj =>
                {
                return
                    IndexDriver != null &&
                    !string.IsNullOrEmpty(TransportType) &&
                    NumberOfSeats > 0 &&
                    !string.IsNullOrEmpty(TransportNumber) &&
                    (TransportNumber.Length > 0 && TransportNumber.Length <= 10);
                }));
            }
        }

        private void AddTransport()
        {
            var idDriver = DataStorageService.DriversCollection[IndexDriver].Id;

            if (DataStorageService.TransportCollection == null)
                DataStorageService.TransportCollection = new ObservableCollection<Transport>() { new Transport(idDriver, TransportType, NumberOfSeats, TransportNumber) };
                
            else
            {
                if (TransportType != "Trolleybus")
                {
                    bool transportAlreadyExisted = false;

                    foreach (var transport in DataStorageService.TransportCollection)
                    {
                        if (transport.TransportNumber == TransportNumber)
                        {
                            transportAlreadyExisted = true;
                            break;
                        }
                    }

                    if (transportAlreadyExisted)
                    {
                        MessageBox.Show("Transport already registered!");
                        return;
                    }
                }

                DataStorageService.TransportCollection.Add(new Transport(idDriver, TransportType, NumberOfSeats, TransportNumber));
            }

            JsonSerializationService.Serialize(DataStorageService.TransportCollection, "/Data/", "transports.json");

            MessageBox.Show("Transport successfully registered!");
        }


        private RelayCommand _spinnerButtonUpCommand;
        public RelayCommand SpinnerButtonUpCommand
        {
            get
            {
                return _spinnerButtonUpCommand ?? (_spinnerButtonUpCommand = new RelayCommand(obj =>
                {

                    NumberOfSeats++;

                }, obj =>
                {
                    return
                        NumberOfSeats < 999;
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

                    NumberOfSeats--;

                }, obj =>
                {
                    return
                        NumberOfSeats > 1;
                }));
            }
        }
    }
}
