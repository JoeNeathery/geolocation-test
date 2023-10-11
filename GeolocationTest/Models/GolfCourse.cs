using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace GeolocationTest.Models
{
    public class GolfCourse
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        //public string Type { get; set; }

        //public ContextInfo Context { get; set; }
    }

    public class ContextInfo
    {
        public long CourseId { get; set; }

        public bool Active { get; set; }

        public double Score { get; set; }
    }

    public class AddressInfo
    {
        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public string Zip { get; set; }

        public string Formatted { get; set; }
    }

    public class Geolocation
    {
        public double Lat { get; set; }

        public double Lon { get; set; }
    }
}

