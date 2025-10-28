using Domine.Entities;
using Domine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Interfaces
{
    public interface IMembershipRepository : IBaseRepository<Membership>
    {
        Task<Membership?> Get(MembershipType membership);
    }
}
