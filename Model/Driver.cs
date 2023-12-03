using System;
using System.Text.Json.Serialization;

namespace PublicTransportRoutes.Model
{
    public class Driver
    {
        private Guid _id;
        public Guid Id => _id;

        private string _fullName;
        public string FullName => _fullName;

        private string _phone;
        public string Phone => _phone;

        public Driver(string fullName, string phone)
        {
            _id = Guid.NewGuid();
            _fullName = fullName;
            _phone = phone;
        }

        [JsonConstructor]
        public Driver(Guid Id, string FullName, string Phone)
        {
            _id = Id;
            _fullName = FullName;
            _phone = Phone;
        }

        public override string ToString() => $"{FullName}";
    }
}
