using Domine.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class eCommerceContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {

        }
    }
}
