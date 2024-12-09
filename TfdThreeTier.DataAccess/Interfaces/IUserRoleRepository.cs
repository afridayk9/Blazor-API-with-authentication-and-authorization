using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAllAsync();
    Task<UserRole> GetByIdAsync(int id);
    Task<UserRole> CreateAsync(UserRole userRole);
    Task<UserRole> UpdateAsync(UserRole userRole);
    Task<bool> DeleteAsync(int id);
}
