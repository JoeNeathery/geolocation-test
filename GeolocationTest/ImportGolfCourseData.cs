using System.Runtime.Intrinsics.Arm;
using GeolocationTest.Models;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GeolocationTest
{
    public static class ImportGolfCourseData
    {
        public static async void Import(MongoClient client)
        {
            var db = client.GetDatabase("GolfNow");
            var collection = db.GetCollection<GolfCourse>("GolfCourse");
            var courses = new List<GolfCourse>();
            using (var reader = new StreamReader(@"/Users/a206709340/workspace/geolocation-test/data.tsv"))
            {
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split('\t');
                    courses.Add(new GolfCourse
                    {
                        Id = ObjectId.GenerateNewId(),
                        Name = values[0],
                        Location = new MongoDB.Driver.GeoJsonObjectModel.GeoJsonPoint<MongoDB.Driver.GeoJsonObjectModel.GeoJson2DGeographicCoordinates>(new MongoDB.Driver.GeoJsonObjectModel.GeoJson2DGeographicCoordinates(double.Parse(values[2]), double.Parse(values[1]))),
                        Address = values[3]
                    });
                }
            }

            collection.InsertMany(courses);

            //try
            //{
            //    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            //    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}

