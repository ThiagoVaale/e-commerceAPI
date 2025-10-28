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
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly eCommerceContext _context;
        public ClientRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }
    }
}
