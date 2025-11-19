using Domine.Entities;
using Domine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class RetailRepository : BaseRepository<RetailClient>, IRetailRepository
    {
        private readonly eCommerceContext _context;
        public RetailRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }

    }
}
