using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterPatternController(ICharacterPatternRepo characterPatternRepo) : ControllerBase
{
    
    [HttpGet("byCharacter/{characterId}")]
    public async Task<IActionResult> GetCharacterPatternsByCharacterId(int characterId)
    {
        var data = await characterPatternRepo.GetCharacterPatternsByCharacterIdAsync(characterId);
        return Ok(data);
    }
}
