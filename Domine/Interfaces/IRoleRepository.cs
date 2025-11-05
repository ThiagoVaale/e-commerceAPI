using Domine.Entities;
using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<List<Role>> GetAsync();
        Task<Role?> GetAsync(RoleType roleName);
    }
}
