using RepsitoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public class PublisherRepository : IRepository<Publisher>,IPublisherRepository
    {
        ApplicationDbContext Context;
        public PublisherRepository(ApplicationDbContext context)
        {
            Context = context;

        }

        public void Create(Publisher model)
        {
            Context.Publishers.Add(model);
        }

        public IEnumerable<Publisher> Get(Func<Publisher, bool> condition)
        {
            return Context.Publishers.Where(condition);
        }

        public IEnumerable<Publisher> Get()
        {
            return Context.Publishers;
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
