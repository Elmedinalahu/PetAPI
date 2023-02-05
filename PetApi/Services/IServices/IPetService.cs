using PetApi.Models;

namespace PetApi.Services.IServices
{
    public interface IPetService
    {
        Task<Pet> GetPet(string id);
        Task<List<Pet>> GetPets();
        Task CreatePet(Pet pet);
        Task<bool> UpdatePet(string id, Pet pet);
        Task<bool> DeletePet(string id);

    }
}
