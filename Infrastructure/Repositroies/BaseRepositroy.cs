using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Repositroies
{
    public class BaseRepositroy<T> : IRepositroy<T> where T : class
    {
        private DbContext DbContext;
        protected DbSet<T> Dbset;

        public BaseRepositroy(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Application DbContext is Null");
            }
            DbContext = context;
            Dbset = DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetALL()
        {
            return Dbset;
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includedProprites = "")
        {
            IQueryable<T> query = Dbset;

            if (filter != null)
            {
                query.Where(filter);
            }

            query = includedProprites.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }

        public virtual T GetById(int id)
        {
            return Dbset.Find(id);
        }

        public T GetFristOrDefult(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return Dbset.FirstOrDefault(filter);

            return null;
        }

        public IQueryable<T> GetAllSorted<Tkey>(Expression<Func<T, Tkey>> sortingExpression = null)
        {
            return Dbset.OrderBy<T, Tkey>(sortingExpression);
        }

        public T Insert(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                Dbset.Add(entity);
            }

            return entity;
        }

        public void Update(T enyity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(enyity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                Dbset.Attach(enyity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted) {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else {
                Dbset.Attach(entity);
                Dbset.Remove(entity);
            }
        }

        public void Delete(int entityId) {
            T entity = Dbset.Find(entityId);
            if (entity == null)
                return;
            Delete(entity);
        }

    }
}
