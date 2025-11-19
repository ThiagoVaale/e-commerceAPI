using Domine.Entities;
using Domine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly eCommerceContext _context;
        public EmployeeRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.UserID == userId);
        }

    }
}
