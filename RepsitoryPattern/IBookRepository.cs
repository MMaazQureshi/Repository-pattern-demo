using RepsitoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public interface IBookRepository:IRepository<Book>
    {
        IQueryable<Book> GetByCategory(string categoryName);

    }
}
