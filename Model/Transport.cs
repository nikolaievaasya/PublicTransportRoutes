using System;
using System.Text.Json.Serialization;

namespace PublicTransportRoutes.Model
{
    public class Transport
    {
        private Guid _id;
        public Guid Id => _id;

        private Guid _idDriver;
        public Guid IdDriver => _idDriver;

        private string _type;
        public string Type => _type;

        private int _numberOfSeats;
        public int NumberOfSeats => _numberOfSeats;

        private string _transportNumber;
        public string TransportNumber => _transportNumber;

        public Transport(Guid idDriver, string type, int numberOfSeats, string transportNumber) 
        {
            _id = Guid.NewGuid();
            _idDriver = idDriver;
            _type = type;
            _numberOfSeats = numberOfSeats;
            _transportNumber = transportNumber;
        }

        [JsonConstructor]
        public Transport(Guid Id, Guid IdDriver, string Type, int NumberOfSeats, string TransportNumber)
        {
            _id = Id;
            _idDriver = IdDriver;
            _type = Type;
            _numberOfSeats = NumberOfSeats;
            _transportNumber = TransportNumber;
        }

        public override string ToString() => $"{Type} - {TransportNumber}";
    }
}
