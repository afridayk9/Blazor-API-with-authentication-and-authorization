using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComponentController : ControllerBase
{
    private readonly IComponentRepo _componentRepo;
    

    public ComponentController(IComponentRepo componentRepo)
    {
        _componentRepo = componentRepo;
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _componentRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _componentRepo.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpGet("byCharacter/{characterId}")]
    public async Task<IActionResult> GetComponentsByCharacterId(int characterId)
    {
        var data = await _componentRepo.GetComponentsByCharacterIdAsync(characterId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComponent([FromBody] Component component)
    {
        if (component == null)
        {
            return BadRequest("Component cannot be null.");
        }

        try
        {
            var createdComponent = await _componentRepo.CreateAsync(component);
            return CreatedAtAction(nameof(GetById), new { id = createdComponent.Id }, createdComponent);
        }
        catch (Exception ex)
        {
            // Log the error (you can use a logging framework like Serilog, NLog, etc.)
            Console.Error.WriteLine($"Error creating component: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the component.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Component componentDto)
    {
        var response = await _componentRepo.UpdateAsync(componentDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _componentRepo.DeleteAsync(id);
        return Ok(response);
    }
}












