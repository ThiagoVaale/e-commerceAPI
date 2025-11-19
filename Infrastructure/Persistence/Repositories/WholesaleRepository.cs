using Domine.Entities;
using Domine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class WholesaleRepository : BaseRepository<WholesaleClient>, IWholesaleRepository
    {
        private readonly eCommerceContext _context;
        public WholesaleRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }
    }
}
