using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComponentController(IComponentRepo component) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await component.GetAllAsync();
        return Ok(data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await component.GetByIdAsync(id);
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Component componentDto)
    {
        var response = await component.CreateAsync(componentDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Component componentDto)
    {
        var response = await component.UpdateAsync(componentDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await component.DeleteAsync(id);
        return Ok(response);
    }
}
