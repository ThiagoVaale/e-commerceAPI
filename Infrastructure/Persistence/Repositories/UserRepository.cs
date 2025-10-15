using Domine.Entities;
using Domine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly eCommerceContext _context;
        public UserRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }
    }
}
