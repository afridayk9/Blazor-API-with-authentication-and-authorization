using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;
using TfdThreeTier.DataAccess.Repositiories;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComponentMaterialController : ControllerBase
{
    private readonly IComponentMaterialRepo _componentMaterialRepo;

    public ComponentMaterialController(IComponentMaterialRepo componentMaterialRepo)
    {
        _componentMaterialRepo = componentMaterialRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _componentMaterialRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _componentMaterialRepo.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("byComponent/{componentId}")]
    public async Task<IActionResult> GetByComponentId(int componentId)
    {
        var data = await _componentMaterialRepo.GetComponentMaterialsByComponentIdAsync(componentId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ComponentMaterial componentMaterial)
    {
        if (componentMaterial == null)
        {
            return BadRequest("ComponentMaterial cannot be null.");
        }

        try
        {
            var createdComponentMaterial = await _componentMaterialRepo.CreateAsync(componentMaterial);
            return CreatedAtAction(nameof(GetById), new { id = createdComponentMaterial.ComponentId }, createdComponentMaterial);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating component material: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the component material: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ComponentMaterial componentMaterial)
    {
        if (componentMaterial == null)
        {
            return BadRequest("ComponentMaterial cannot be null.");
        }

        try
        {
            var updatedComponentMaterial = await _componentMaterialRepo.UpdateAsync(componentMaterial);
            return Ok(updatedComponentMaterial);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating component material: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the component material: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await _componentMaterialRepo.DeleteAsync(id);
            return Ok(response.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting component material: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the component material: {ex.Message}");
        }
    }
}





