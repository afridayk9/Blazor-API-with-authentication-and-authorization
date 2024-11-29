using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterController(ICharacterRepo character) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await character.GetAllAsync();
        return Ok(data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await character.GetByIdAsync(id);
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Character characterDto)
    {
        var response = await character.CreateAsync(characterDto);        
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Character characterDto)
    {
        var response = await character.UpdateAsync(characterDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await character.DeleteAsync(id);
        return Ok(response);
    }
}
