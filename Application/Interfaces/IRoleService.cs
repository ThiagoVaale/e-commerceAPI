using Application.Dtos.Requests;
using Domine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> Get();
        Task<Role?> Create(RoleCreate roleCreate);
    }
}
