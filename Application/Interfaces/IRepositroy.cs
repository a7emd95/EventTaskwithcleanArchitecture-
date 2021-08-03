using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepositroy<T> where T : class
    {
        IQueryable<T> GetALL();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includedProprites = "");
        T GetById(int id);
        T GetFristOrDefult(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllSorted<Tkey>(Expression<Func<T, Tkey>> sortingExpression = null);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int entityId);
    }
}
