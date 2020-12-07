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
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Get()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
