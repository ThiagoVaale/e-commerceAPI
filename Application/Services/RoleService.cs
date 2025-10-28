using Application.Dtos.Requests;
using Application.Interfaces;
using Domine.Entities;
using Domine.Enums;
using Domine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _roleRepository.Get();
        }

        public async Task<Role?> Create(RoleCreate roleCreate)
        {
            Role? existing = await _roleRepository.GetAsync(roleCreate.Name);
            if (existing != null)
            {
                throw new InvalidOperationException($"Role '{roleCreate.Name}' already exists.");
            }

            Role role = new Role
            {
                Name = roleCreate.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _roleRepository.Add(role);
            await _roleRepository.SaveChangesAsync();
            return role;
        }
    }
}
