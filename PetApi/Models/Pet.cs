using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PetApi.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Breed")]
        public string Breed { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }
    }
}
