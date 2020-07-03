using ITI.Luxorna.Entities;
using ITI.Luxorna.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Repositories
{
    public class GenericRepository<T> where T:BaseModel
    {
        private DbSet<T> dbSet;
        public EntitiesContext Context { get; set; }
        public GenericRepository(EntitiesContext _Context)
        {
            Context = _Context;
            dbSet = Context.Set<T>();
        }
        public T Add(T t)
        {
            return dbSet.Add(t);

        }
        public T Update(T t)
        {
            if (!dbSet.Local.Any(i => i.ID == t.ID))
                dbSet.Attach(t);
            Context.Entry(t).State = EntityState.Modified;
            return t;
        }
        public void Remove(T t)
        {
            if (!dbSet.Local.Any(i => i.ID == t.ID))
                dbSet.Attach(t);
            dbSet.Remove(t);
        }
        public T GetByID(int ID)
        {
            return dbSet.FirstOrDefault(i => i.ID == ID);
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public IQueryable<T> GetFilter(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }
    }
}
