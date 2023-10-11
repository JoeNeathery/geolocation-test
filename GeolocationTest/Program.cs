using GeolocationTest;
using GeolocationTest.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver.Search;
using NetTopologySuite.Geometries;

const string connectionUri = "mongodb+srv://jneathery1201:KAYcf0QLSKVhyJkR@geolocationtest.6dvyzgy.mongodb.net/?retryWrites=true&w=majority";
var settings = MongoClientSettings.FromConnectionString(connectionUri);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);
//ImportGolfCourseData.Import(client);

if (client != null)
{
    var query = new Query
    {
        Text = "Qua",
        Geo = new Geolocation { Lat = 41.422167, Lon = -97.368208 }
    };

    var db = client.GetDatabase("GolfNow");
    var collection = db.GetCollection<GolfCourse>("GolfCourse");

    var queryDef = QueryDefinitions.GetTextAndGeoWithinDefinition(query.Text, query.Geo.Lon, query.Geo.Lat, 10000);
    var results = await collection.Aggregate().Search(queryDef).Limit(20).ToListAsync();

    Console.Write("TEST");


}

//var results = await collection.Aggregate()
//                            .Search(search).Limit(20).ToListAsync();




