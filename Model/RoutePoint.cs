using System;
using System.Text.Json.Serialization;

namespace PublicTransportRoutes.Model
{
    public class RoutePoint
    {
        private Guid _id;
        public Guid Id => _id;

        private Guid _idRoute;
        public Guid IdRoute => _idRoute;

        private Guid _idBusStop;
        public Guid IdBusStop => _idBusStop;

        private int _pointOrder;
        public int PointOrder => _pointOrder;

        public RoutePoint(Guid idRoute, Guid idBusStop, int pointOrder)
        {
            _id = Guid.NewGuid();
            _idRoute = idRoute;
            _idBusStop = idBusStop;
            _pointOrder = pointOrder;
        }

        [JsonConstructor]
        public RoutePoint(Guid Id, Guid IdRoute, Guid IdBusStop, int PointOrder)
        {
            _id = Id;
            _idRoute = IdRoute;
            _idBusStop = IdBusStop;
            _pointOrder = PointOrder;
        }
    }
}
