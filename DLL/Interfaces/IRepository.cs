using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetList();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task Save();
    }
}
