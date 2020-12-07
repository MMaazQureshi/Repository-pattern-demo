using RepsitoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepsitoryPattern
{
    public class UnitOfWork
    {
       public ApplicationDbContext Context;

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;

        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
