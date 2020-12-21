using RepsitoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public class AuthorRepository :IAuthorRepository
    {
        private ApplicationDbContext Context;

        public AuthorRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Create(Author model)
        {
            Context.authors.Add(model);
        }

        public IEnumerable<Author> Get(Func<Author, bool> condition)
        {
            return Context.authors.Where(condition);

        }

        public IEnumerable<Author> Get()
        {
            return Context.authors;
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
