using Domine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Interfaces
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string username);
    }
}
