using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
{
    

    [HttpPost("register")]
    public async Task<IActionResult> CreateAsync(Register user)
    {
        if (user is null) return BadRequest("User is null on register request");
        var result = await accountInterface.CreateAsync(user);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> SignInAsync(Login user)
    {
        if (user is null) return BadRequest("User is null on login API request");
        var result = await accountInterface.SignInAsync(user);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
    {
        if (token is null) return BadRequest("Token is null on refresh token API request");
        var result = await accountInterface.RefreshTokenAsync(token);
        return Ok(result);
    }
}


