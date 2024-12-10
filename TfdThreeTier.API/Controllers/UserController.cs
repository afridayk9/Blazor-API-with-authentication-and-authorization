using Microsoft.AspNetCore.Mvc;
using BaseLibrary.Entities;
using TfdThreeTier.DataAccess.Interfaces;
using BaseLibrary.DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly ILogger<UserController> _logger;


    public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _logger = logger;

    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersWithRoles()
    {
        var users = await _userRepository.GetAllAsync();
        var roles = await _roleRepository.GetAllAsync();
        var userRoles = await _userRoleRepository.GetAllAsync();

        var userWithRoles = users.Select(user => new UserDetail
        {
            Id = user.Id,
            Email = user.Email,
            Roles = userRoles.Where(ur => ur.UserId == user.Id)
                             .Select(ur => roles.FirstOrDefault(r => r.Id == ur.RoleId)?.RoleName)
                             .ToList()
        }).ToList();

        foreach (var user in userWithRoles)
        {
            _logger.LogInformation($"User ID: {user.Id}, Email: {user.Email}");
        }

        return Ok(userWithRoles);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDetail userDetail)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Email = userDetail.Email;
        await _userRepository.UpdateAsync(user);

        var userRoles = await _userRoleRepository.GetAllAsync();
        var existingUserRoles = userRoles.Where(ur => ur.UserId == id).ToList();

        foreach (var role in existingUserRoles)
        {
            await _userRoleRepository.DeleteAsync(role.Id);
        }

        foreach (var roleName in userDetail.Roles)
        {
            var role = await _roleRepository.GetAllAsync();
            var roleId = role.FirstOrDefault(r => r.RoleName == roleName)?.Id;
            if (roleId != null)
            {
                await _userRoleRepository.CreateAsync(new UserRole { UserId = id, RoleId = roleId });
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteAsync(id);
        return NoContent();
    }
}



