using PublicTransportRoutes.Core;
using PublicTransportRoutes.Model;
using PublicTransportRoutes.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PublicTransportRoutes.ViewModel
{
    internal class AddTransportRouteViewModel : Core.ViewModel
    {
        public AddTransportRouteViewModel(INavigationService navigationService, IDataStorageService dataStorageService) : base(navigationService, dataStorageService)
        {
            StartTimeHours = 0;
            StartTimeMinutes = 0;
            EndTimeHours = 0;
            EndTimeMinutes = 0;
        }

        private int _indexTransport;
        public int IndexTransport
        {
            get { return _indexTransport; }
            set
            {
                _indexTransport = value;
                OnPropertyChanged(nameof(IndexTransport));
            }
        }

        private int _indexRoute;
        public int IndexRoute
        {
            get { return _indexRoute; }
            set
            {
                _indexRoute = value;
                OnPropertyChanged(nameof(IndexRoute));
            }
        }

        private string _weekday;
        public string Weekday
        {
            get { return _weekday; }
            set
            {
                _weekday = value;
                OnPropertyChanged(nameof(Weekday));
            }
        }


        private int _startTimeHours;
        public int StartTimeHours
        {
            get { return _startTimeHours; }
            set
            {
                _startTimeHours = value;
                OnPropertyChanged(nameof(StartTimeHours));
            }
        }

        private int _startTimeMinutes;
        public int StartTimeMinutes
        {
            get { return _startTimeMinutes; }
            set
            {
                _startTimeMinutes = value;
                OnPropertyChanged(nameof(StartTimeMinutes));
            }
        }

        private int _endTimeHours;
        public int EndTimeHours
        {
            get { return _endTimeHours; }
            set
            {
                _endTimeHours = value;
                OnPropertyChanged(nameof(EndTimeHours));
            }
        }

        private int _endTimeMinutes;
        public int EndTimeMinutes
        {
            get { return _endTimeMinutes; }
            set
            {
                _endTimeMinutes = value;
                OnPropertyChanged(nameof(EndTimeMinutes));
            }
        }


        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        private RelayCommand _addTransportRouteCommand;
        public RelayCommand AddTransportRouteCommand
        {
            get
            {
                return _addTransportRouteCommand ?? (_addTransportRouteCommand = new RelayCommand(obj =>
                {

                    AddTransportRoute();

                }, obj =>
                {
                    return
                        IndexTransport != null &&
                        IndexRoute != null &&
                        !string.IsNullOrEmpty(Weekday);
                }));
            }
        }

        private void AddTransportRoute()
        {
            var idTransport = DataStorageService.TransportCollection[IndexTransport].Id;
            var idRoute = DataStorageService.RoutesCollection[IndexRoute].Id;
            
            TimeOnly startTime = new TimeOnly(StartTimeHours, StartTimeMinutes);
            TimeOnly endTime = new TimeOnly(EndTimeHours, EndTimeMinutes);

            if (endTime < startTime)
            {
                MessageBox.Show("Start time must be less then end time!");
                return;
            }

            if (DataStorageService.TransportRoutesCollection == null)
                DataStorageService.TransportRoutesCollection = new ObservableCollection<TransportRoute>()
                { 
                    new TransportRoute(DataStorageService.TransportCollection[IndexTransport].Id, DataStorageService.RoutesCollection[IndexRoute].Id, startTime, endTime) 
                };
                
            else
            {
                bool transportRouteAlreadyExisted = false;

                foreach (var transportRoute in DataStorageService.TransportRoutesCollection)
                {
                    if (transportRoute.IdTransport == idTransport && transportRoute.IdRoute == idRoute)
                    {
                        transportRouteAlreadyExisted = true;
                        break;
                    }
                }

                if (transportRouteAlreadyExisted)
                {
                    MessageBox.Show("Transport route already registered!");
                    return;
                }

                DataStorageService.TransportRoutesCollection.Add(new TransportRoute(DataStorageService.TransportCollection[IndexTransport].Id, DataStorageService.RoutesCollection[IndexRoute].Id, startTime, endTime));
            }

            JsonSerializationService.Serialize(DataStorageService.TransportRoutesCollection, "/Data/", "transportRoutes.json");

            MessageBox.Show("Transport route successfully registered!");
        }

        private RelayCommand _increaseStartTimeHourCommand;
        public RelayCommand IncreaseStartTimeHourCommand
        {
            get
            {
                return _increaseStartTimeHourCommand ?? (_increaseStartTimeHourCommand = new RelayCommand(obj =>
                {

                    StartTimeHours++;

                }, obj =>
                {
                    return
                        StartTimeHours < 24;
                }));
            }
        }

        private RelayCommand _increaseEndTimeHourCommand;
        public RelayCommand IncreaseEndTimeHourCommand
        {
            get
            {
                return _increaseEndTimeHourCommand ?? (_increaseEndTimeHourCommand = new RelayCommand(obj =>
                {

                    EndTimeHours++;

                }, obj =>
                {
                    return
                        EndTimeHours < 24;
                }));
            }
        }


        private RelayCommand _decreaseStartTimeHourCommand;
        public RelayCommand DecreaseStartTimeHourCommand
        {
            get
            {
                return _decreaseStartTimeHourCommand ?? (_decreaseStartTimeHourCommand = new RelayCommand(obj =>
                {

                    StartTimeHours--;

                }, obj =>
                {
                    return
                        StartTimeHours > 0;
                }));
            }
        }

        private RelayCommand _decreaseEndTimeHourCommand;
        public RelayCommand DecreaseEndTimeHourCommand
        {
            get
            {
                return _decreaseEndTimeHourCommand ?? (_decreaseEndTimeHourCommand = new RelayCommand(obj =>
                {

                    EndTimeHours--;

                }, obj =>
                {
                    return
                        EndTimeHours > 0;
                }));
            }
        }


        private RelayCommand _increaseStartTimeMinuteCommand;
        public RelayCommand IncreaseStartTimeMinuteCommand
        {
            get
            {
                return _increaseStartTimeMinuteCommand ?? (_increaseStartTimeMinuteCommand = new RelayCommand(obj =>
                {

                    StartTimeMinutes++;

                }, obj =>
                {
                    return
                        StartTimeMinutes < 59;
                }));
            }
        }

        private RelayCommand _increaseEndTimeMinuteCommand;
        public RelayCommand IncreaseEndTimeMinuteCommand
        {
            get
            {
                return _increaseEndTimeMinuteCommand ?? (_increaseEndTimeMinuteCommand = new RelayCommand(obj =>
                {

                    EndTimeMinutes++;

                }, obj =>
                {
                    return
                        EndTimeMinutes < 59;
                }));
            }
        }


        private RelayCommand _decreaseStartTimeMinuteCommand;
        public RelayCommand DecreaseStartTimeMinuteCommand
        {
            get
            {
                return _decreaseStartTimeMinuteCommand ?? (_decreaseStartTimeMinuteCommand = new RelayCommand(obj =>
                {

                    StartTimeMinutes--;

                }, obj =>
                {
                    return
                        StartTimeMinutes > 0;
                }));
            }
        }

        private RelayCommand _decreaseEndTimeMinuteCommand;
        public RelayCommand DecreaseEndTimeMinuteCommand
        {
            get
            {
                return _decreaseEndTimeMinuteCommand ?? (_decreaseEndTimeMinuteCommand = new RelayCommand(obj =>
                {

                    EndTimeMinutes--;

                }, obj =>
                {
                    return
                        EndTimeMinutes > 0;
                }));
            }
        }
    }
}
