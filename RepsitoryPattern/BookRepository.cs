using RepsitoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public class BookRepository : IBookRepository,IRepository<Book>

    {
        ApplicationDbContext Context;
        public BookRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Create(Book model)
        {
            Context.books.Add(model);
        }

        public IEnumerable<Book> Get(Func<Book, bool> condition)
        {
           var books = Context.books.Where(condition);
            return books;
        }
        public IEnumerable<Book> Get()
        {
            var books = Context.books;
            return books;
        }

        public IQueryable<Book> GetByCategory(string categoryName)
        {
            var books = Context.books.Where(x=>x.Category==categoryName);
            return books;
        }

        public Book GetById(int id)
        {
            var books = Context.books.Where(x=>x.BookId==id).First();
            return books;
        }
    }
}
