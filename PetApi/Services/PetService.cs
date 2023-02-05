using MongoDB.Driver;
using PetApi.Data;
using PetApi.Models;
using PetApi.Services.IServices;

namespace PetApi.Services
{
    public class PetService : IPetService
    {
        private readonly PetDbContext _context;


        public PetService(PetDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> GetPet(string id)
        {
            var pet = Builders<Pet>.Filter.Eq("Id", id);
            return await _context.Pets.Find(pet).FirstOrDefaultAsync();
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _context.Pets.Find(p => true).ToListAsync();
        }

        public async Task CreatePet(Pet pet)
        {
            await _context.Pets.InsertOneAsync(pet);
        }

        public async Task<bool> UpdatePet(string id, Pet pet)
        {
            var filters = Builders<Pet>.Filter.Eq("Id", id);
            var update = Builders<Pet>.Update
                                .Set("Name", pet.Name)
                                .Set("Breed", pet.Breed)
                                .Set("Age", pet.Age);
            var result = await _context.Pets.UpdateOneAsync(filters, update);

            return result.IsAcknowledged;
        }

        public async Task<bool> DeletePet(string id)
        {
            var filter = Builders<Pet>.Filter.Eq(m => m.Id, id);
            var result = await _context.Pets.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }


    }
}
