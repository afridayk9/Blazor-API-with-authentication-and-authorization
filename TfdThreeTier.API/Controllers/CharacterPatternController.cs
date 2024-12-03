using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterPatternController : ControllerBase
{
    private readonly ICharacterPatternRepo _characterPatternRepo;
    private readonly IComponentPatternRepo _componentPatternRepo;

    public CharacterPatternController(ICharacterPatternRepo characterPatternRepo, IComponentPatternRepo componentPatternRepo)
    {
        _characterPatternRepo = characterPatternRepo;
        _componentPatternRepo = componentPatternRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _characterPatternRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{characterId}/{patternId}")]
    public async Task<IActionResult> GetById(int characterId, int patternId)
    {
        var data = await _characterPatternRepo.GetByIdAsync(characterId, patternId);
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("byCharacter/{characterId}")]
    public async Task<IActionResult> GetByCharacterId(int characterId)
    {
        var data = await _characterPatternRepo.GetCharacterPatternsByCharacterIdAsync(characterId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CharacterPattern characterPattern)
    {
        if (characterPattern == null)
        {
            return BadRequest("CharacterPattern cannot be null.");
        }

        try
        {
            // Check if the character pattern already exists
            var existingCharacterPattern = await _characterPatternRepo.GetByIdAsync(characterPattern.CharacterId, characterPattern.PatternId);
            if (existingCharacterPattern != null)
            {
                return Conflict("CharacterPattern with the same CharacterId and PatternId already exists.");
            }

            var createdCharacterPattern = await _characterPatternRepo.CreateAsync(characterPattern);
            return CreatedAtAction(nameof(GetById), new { characterId = createdCharacterPattern.CharacterId, patternId = createdCharacterPattern.PatternId }, createdCharacterPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating character pattern: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the character pattern: {ex.Message}");
        }
    }

    [HttpPost("establishRelationship")]
    public async Task<IActionResult> EstablishRelationship([FromBody] CharacterPattern characterPattern, [FromQuery] int componentId)
    {
        if (characterPattern == null)
        {
            return BadRequest("CharacterPattern cannot be null.");
        }

        try
        {
            // Check if the character pattern already exists
            var existingCharacterPattern = await _characterPatternRepo.GetByIdAsync(characterPattern.CharacterId, characterPattern.PatternId);
            if (existingCharacterPattern != null)
            {
                return Conflict("CharacterPattern with the same CharacterId and PatternId already exists.");
            }

            // Create the character pattern
            var createdCharacterPattern = await _characterPatternRepo.CreateAsync(characterPattern);

            // Create the component pattern
            var componentPattern = new ComponentPattern
            {
                ComponentId = componentId,
                PatternId = characterPattern.PatternId
            };
            await _componentPatternRepo.CreateAsync(componentPattern);

            return CreatedAtAction(nameof(GetById), new { characterId = createdCharacterPattern.CharacterId, patternId = createdCharacterPattern.PatternId }, createdCharacterPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error establishing relationship: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while establishing the relationship: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CharacterPattern characterPattern)
    {
        if (characterPattern == null)
        {
            return BadRequest("CharacterPattern cannot be null.");
        }

        try
        {
            var updatedCharacterPattern = await _characterPatternRepo.UpdateAsync(characterPattern);
            return Ok(updatedCharacterPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating character pattern: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the character pattern: {ex.Message}");
        }
    }

    [HttpDelete("{characterId}/{patternId}")]
    public async Task<IActionResult> Delete(int characterId, int patternId)
    {
        try
        {
            var response = await _characterPatternRepo.DeleteAsync(characterId, patternId);
            return Ok(response.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting character pattern: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the character pattern: {ex.Message}");
        }
    }

}



