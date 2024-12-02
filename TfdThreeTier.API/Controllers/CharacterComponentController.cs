using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterComponentController : ControllerBase
    {
        private readonly ICharacterComponentRepo _characterComponentRepo;

        public CharacterComponentController(ICharacterComponentRepo characterComponentRepo)
        {
            _characterComponentRepo = characterComponentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _characterComponentRepo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _characterComponentRepo.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("byCharacter/{characterId}")]
        public async Task<IActionResult> GetByCharacterId(int characterId)
        {
            var data = await _characterComponentRepo.GetCharacterComponentsByCharacterIdAsync(characterId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CharacterComponent characterComponent)
        {
            if (characterComponent == null)
            {
                return BadRequest("CharacterComponent cannot be null.");
            }

            try
            {
                var createdCharacterComponent = await _characterComponentRepo.CreateAsync(characterComponent);
                return CreatedAtAction(nameof(GetById), new { id = createdCharacterComponent.CharacterId }, createdCharacterComponent);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating character component: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the character component: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CharacterComponent characterComponent)
        {
            if (characterComponent == null)
            {
                return BadRequest("CharacterComponent cannot be null.");
            }

            try
            {
                var updatedCharacterComponent = await _characterComponentRepo.UpdateAsync(characterComponent);
                return Ok(updatedCharacterComponent);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating character component: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the character component: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _characterComponentRepo.DeleteAsync(id);                
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                // Log the error (you can use a logging framework like Serilog, NLog, etc.)
                Console.Error.WriteLine($"Error deleting character component: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the character component: {ex.Message}");
            }
        }
    }
}

