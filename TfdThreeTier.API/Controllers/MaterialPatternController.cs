using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MaterialPatternController : ControllerBase
{
    private readonly IMaterialPatternRepo _materialPatternRepo;

    public MaterialPatternController(IMaterialPatternRepo materialPatternRepo)
    {
        _materialPatternRepo = materialPatternRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _materialPatternRepo.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _materialPatternRepo.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("byMaterial/{materialId}")]
    public async Task<IActionResult> GetByMaterialId(int materialId)
    {
        var data = await _materialPatternRepo.GetMaterialPatternsByMaterialIdAsync(materialId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaterialPattern materialPattern)
    {
        if (materialPattern == null)
        {
            return BadRequest("MaterialPattern cannot be null.");
        }

        try
        {
            var createdMaterialPattern = await _materialPatternRepo.CreateAsync(materialPattern);
            return CreatedAtAction(nameof(GetById), new { id = createdMaterialPattern.MaterialId }, createdMaterialPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating material pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the material pattern: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] MaterialPattern materialPattern)
    {
        if (materialPattern == null)
        {
            return BadRequest("MaterialPattern cannot be null.");
        }

        try
        {
            var updatedMaterialPattern = await _materialPatternRepo.UpdateAsync(materialPattern);
            return Ok(updatedMaterialPattern);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating material pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the material pattern: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await _materialPatternRepo.DeleteAsync(id);            
                
            
            return Ok(response.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting material pattern: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the material pattern: {ex.Message}");
        }
    }
}
