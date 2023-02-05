using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PetApi.Models;
using PetApi.Models.Dto;
using PetApi.Services.IServices;

namespace PetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pets = await _petService.GetPets();
            return Ok(pets);
        }

        [HttpGet("{id:length(24)}", Name = "GetPet")]
        public async Task<IActionResult> Get(string id)
        {
            var pet = await _petService.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetDto petDto)
        {
            var pet = new Pet
            {
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age
            };

            await _petService.CreatePet(pet);

            return Ok(pet);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, PetDto petDto)
        {
            var pet = new Pet
            {
                Id = id,
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age
            };

            var result = await _petService.UpdatePet(id, pet);

            return Ok(result);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pet = _petService.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            await _petService.DeletePet(id);

            return NoContent();
        }

    }
}
