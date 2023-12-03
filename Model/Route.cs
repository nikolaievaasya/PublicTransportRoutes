using System;
using System.Text.Json.Serialization;

namespace PublicTransportRoutes.Model
{
    public class Route
    {
        private Guid _id;
        public Guid Id => _id;

        private string _title;
        public string Title => _title;

        public Route(string title)
        {
            _id = Guid.NewGuid();
            _title = title;
        }

        [JsonConstructor]
        public Route(Guid Id, string Title)
        {
            _id = Id;
            _title = Title;
        }

        public override string ToString() => $"{Title}";
    }
}
