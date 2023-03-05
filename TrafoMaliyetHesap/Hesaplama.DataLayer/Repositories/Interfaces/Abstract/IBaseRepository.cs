using Hesaplama.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hesaplama.DataLayer.Repositories.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Active(T entity);
        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetByDefaults(Expression<Func<T, bool>> exp);

        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        T Get(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
    }
}
