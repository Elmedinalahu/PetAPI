using MongoDB.Bson.Serialization.Attributes;

namespace PetApi.Models.Dto
{
    public class PetDto
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Breed")]
        public string Breed { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }
    }
}
