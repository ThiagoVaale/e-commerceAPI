using Domine.Entities;
using Domine.Enums;
using Domine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly eCommerceContext _context;
        public ClientRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Client?> GetClientByUserIdAsync(Guid userId)
        {
            return await _context.Clients
                .Include(c => c.RetailClient)
                    .ThenInclude(rc => rc.Membership)
                .Include(c => c.WholesaleClient)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
