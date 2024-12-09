using Microsoft.AspNetCore.Mvc;
using BaseLibrary.Entities;
using TfdThreeTier.DataAccess.Interfaces;
using BaseLibrary.DTOs;

namespace TfdThreeTier.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersWithRoles()
    {
        var users = await _userRepository.GetAllAsync();
        var roles = await _roleRepository.GetAllAsync();
        var userRoles = await _userRoleRepository.GetAllAsync();

        var userWithRoles = users.Select(user => new UserDetail
        {
            Email = user.Email,
            Roles = userRoles.Where(ur => ur.UserId == user.Id)
                             .Select(ur => roles.FirstOrDefault(r => r.Id == ur.RoleId)?.RoleName)
                             .ToList()
        }).ToList();

        return Ok(userWithRoles);
    }
}



