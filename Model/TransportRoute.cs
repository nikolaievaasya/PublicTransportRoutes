using System;
using System.Text.Json.Serialization;

namespace PublicTransportRoutes.Model
{
    public class TransportRoute
    {
        private Guid _id;
        public Guid Id => _id;

        private Guid _idTransport;
        public Guid IdTransport => _idTransport;

        private Guid _idRoute;
        public Guid IdRoute => _idRoute;

        private string _weekday;
        public string Weekday => _weekday;

        private TimeOnly _startTime;
        public TimeOnly StartTime => _startTime;

        private TimeOnly _endTime;
        public TimeOnly EndTime => _endTime;

        public TransportRoute(Guid idTransport, Guid idRoute, TimeOnly startTime, TimeOnly endTime)
        {
            _id = Guid.NewGuid();
            _idTransport = idTransport;
            _idRoute = idRoute;
            _startTime = startTime;
            _endTime = endTime;
        }

        [JsonConstructor]
        public TransportRoute(Guid Id, Guid IdTransport, Guid IdRoute, string Weekday, TimeOnly StartTime, TimeOnly EndTime)
        {
            _id = Id;
            _idTransport = IdTransport;
            _idRoute = IdRoute;
            _weekday = Weekday;
            _startTime = StartTime;
            _endTime = EndTime;
        }

    }
}
