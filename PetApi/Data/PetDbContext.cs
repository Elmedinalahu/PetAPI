using MongoDB.Driver;
using PetApi.Models;

namespace PetApi.Data
{
    public class PetDbContext
    {
        private readonly IMongoDatabase _database;

        public PetDbContext()
        {
            var connectionString = System.Environment.GetEnvironmentVariable("ConnectionString");

            var client = new MongoClient("mongodb://db:27017");
            if (client != null)
                _database = client.GetDatabase("PetDB");
        }

        public IMongoCollection<Pet> Pets => _database.GetCollection<Pet>("Pets");
    }
}
