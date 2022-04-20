using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Tool
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string ToolName { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Condition { get; set; }
    }
}