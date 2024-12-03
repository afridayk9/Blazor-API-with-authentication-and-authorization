using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComponentPatternController : ControllerBase
{
    private readonly IComponentPatternRepo _componentPatternRepo;

    public ComponentPatternController(IComponentPatternRepo componentPatternRepo)
    {
        _componentPatternRepo = componentPatternRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _componentPatternRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{componentId}/{patternId}")]
    public async Task<IActionResult> GetById(int componentId, int patternId)
    {
        var data = await _componentPatternRepo.GetByIdAsync(componentId, patternId);
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("byComponent/{componentId}")]
    public async Task<IActionResult> GetByComponentId(int componentId)
    {
        var data = await _componentPatternRepo.GetComponentPatternsByComponentIdAsync(componentId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ComponentPattern componentPattern)
    {
        if (componentPattern == null)
        {
            return BadRequest("ComponentPattern cannot be null.");
        }

        try
        {
            var createdComponentPattern = await _componentPatternRepo.CreateAsync(componentPattern);
            return CreatedAtAction(nameof(GetById), new { componentId = createdComponentPattern.ComponentId, patternId = createdComponentPattern.PatternId }, createdComponentPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating component pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the component pattern: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ComponentPattern componentPattern)
    {
        if (componentPattern == null)
        {
            return BadRequest("ComponentPattern cannot be null.");
        }

        try
        {
            var updatedComponentPattern = await _componentPatternRepo.UpdateAsync(componentPattern);
            return Ok(updatedComponentPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating component pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the component pattern: {ex.Message}");
        }
    }

    [HttpDelete("{componentId}/{patternId}")]
    public async Task<IActionResult> Delete(int componentId, int patternId)
    {
        try
        {
            var response = await _componentPatternRepo.DeleteAsync(componentId, patternId);
            return Ok(response.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting component pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the component pattern: {ex.Message}");
        }
    }
}



