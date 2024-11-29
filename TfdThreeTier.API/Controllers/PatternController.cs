using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatternController(IPatternRepo patternRepo, ILogger<PatternController> logger) : ControllerBase
{
    

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await patternRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await patternRepo.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpGet("byMaterial/{materialId}")]
    public async Task<IActionResult> GetPatternsByMaterialId(int materialId)
    {
        try
        {
            var data = await patternRepo.GetPatternsByMaterialIdAsync(materialId);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching patterns by material ID");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("byComponent/{componentId}")]
    public async Task<IActionResult> GetPatternsByComponentId(int componentId)
    {
        try
        {
            var data = await patternRepo.GetPatternsByComponentIdAsync(componentId);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching patterns by component ID");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("byCharacter/{characterId}")]
    public async Task<IActionResult> GetPatternsByCharacterId(int characterId)
    {
        try
        {
            var data = await patternRepo.GetPatternsByCharacterIdAsync(characterId);
            return Ok(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching patterns by character ID");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pattern patternDto)
    {
        var response = await patternRepo.CreateAsync(patternDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Pattern patternDto)
    {
        var response = await patternRepo.UpdateAsync(patternDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await patternRepo.DeleteAsync(id);
        return Ok(response);
    }
}


