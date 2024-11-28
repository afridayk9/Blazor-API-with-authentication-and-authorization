using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MaterialController(IMaterialRepo material) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await material.GetAllAsync();
        return Ok(data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await material.GetByIdAsync(id);
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Material materialDto)
    {
        var response = await material.CreateAsync(materialDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Material materialDto)
    {
        var response = await material.UpdateAsync(materialDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await material.DeleteAsync(id);
        return Ok(response);
    }
}
