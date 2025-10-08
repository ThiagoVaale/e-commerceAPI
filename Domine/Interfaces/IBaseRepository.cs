using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        T? Get<TId>(TId id);
        Task<List<T>> Get();
        Task Add(T entity);
        Task SaveChangesAsync();
    }
}
