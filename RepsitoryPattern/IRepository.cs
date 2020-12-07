using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public interface IRepository<T> where T : class
    {
        void Create(T model);

        T GetById(int id);

        IEnumerable<T> Get(Func<T, bool> condition);

        IEnumerable<T> Get();

    }
}
