using Domine.Entities;
using Domine.Interfaces;
using Infrastructure.Persistence;
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

        public Client? Get(string name)
        {
            throw new NotImplementedException();
        }

        //public Client? Get(string name) 
        //{
        //    return _context.Clients.FirstOrDefault(c => c. == name);
        //}
    }
}
