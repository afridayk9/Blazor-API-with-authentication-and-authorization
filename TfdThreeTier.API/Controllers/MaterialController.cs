using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Interfaces;
using TfdThreeTier.DataAccess.Repositiories;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MaterialController(IMaterialRepo materialRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await materialRepo.GetAllAsync();
        return Ok(data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await materialRepo.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpGet("byComponent/{componentId}")]
    public async Task<IActionResult> GetPatternsByMaterialId(int componentId)
    {
        var data = await materialRepo.GetMaterialsByComponentIdAsync(componentId);
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMaterial([FromBody] Material material)
    {
        if (material == null)
        {
            return BadRequest("Material cannot be null.");
        }

        try
        {
            var createdMaterial = await materialRepo.CreateAsync(material);
            return CreatedAtAction(nameof(GetById), new { id = createdMaterial.Id }, createdMaterial);
        }
        catch (Exception ex)
        {
            // Log the error (you can use a logging framework like Serilog, NLog, etc.)
            Console.Error.WriteLine($"Error creating component: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the component.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Material materialDto)
    {
        var response = await materialRepo.UpdateAsync(materialDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await materialRepo.DeleteAsync(id);
        return Ok(response);
    }
}
