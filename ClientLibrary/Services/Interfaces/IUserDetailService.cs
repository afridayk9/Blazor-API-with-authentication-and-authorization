using BaseLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Interfaces;
public interface IUserDetailService
{
    Task<List<UserDetail>> GetAllUsersWithRolesAsync();
    Task UpdateUserAsync(UserDetail user);
    Task DeleteUserAsync(int userId);
}

