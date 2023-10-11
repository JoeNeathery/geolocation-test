using System;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace GeolocationTest
{
    public static class QueryDefinitions
    {
        public static BsonDocument GetTextAndGeoWithinDefinition(string text, double lon, double lat, int radiusInMeters)
        {
            // Create a new BsonDocument instance.
            BsonDocument bsonDocument = new BsonDocument();

            // Add a $search field to the BsonDocument instance.
            bsonDocument.Add("index", new BsonDocument());
            bsonDocument.Add("compound", new BsonDocument());

            // Set the index field of the $search field to the name of the index to search.
            bsonDocument["index"] = "default";

            // Add a compound field to the $search field.
            bsonDocument["compound"] = new BsonDocument();

            // Create a new BsonArray instance and add the autocomplete field to it.
            BsonArray mustBsonArray = new BsonArray();
            mustBsonArray.Add(new BsonDocument()
            {
                { "autocomplete", new BsonDocument()
                {
                    { "query", text },
                    { "path", "Name" }
                } }
            });

            // Create a new BsonDocument instance and add the geoWithin field to it.
            BsonDocument geoWithinBsonDocument = new BsonDocument();
            geoWithinBsonDocument.Add("geoWithin", new BsonDocument()
            {
                { "circle", new BsonDocument()
                {
                    { "center", new BsonDocument()
                    {
                        { "type", "Point" },
                        { "coordinates", new BsonArray() { lon, lat } }
                    } },
                    { "radius", radiusInMeters }
                } },
                { "path", "Location" }
            });

            // Add the geoWithinBsonDocument instance to the mustBsonArray.
            mustBsonArray.Add(geoWithinBsonDocument);

            // Set the must field of the compound field to the mustBsonArray instance.
            bsonDocument["compound"]["must"] = mustBsonArray;

            // Return the BsonDocument instance.
            return bsonDocument;
        }
    }
}
