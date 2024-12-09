using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IRoleRepository
{
    Task<List<SystemRoles>> GetAllAsync();
    Task<SystemRoles> GetByIdAsync(int id);
    Task<SystemRoles> CreateAsync(SystemRoles role);
    Task<SystemRoles> UpdateAsync(SystemRoles role);
    Task<bool> DeleteAsync(int id);
}
