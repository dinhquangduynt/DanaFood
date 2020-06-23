using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ThucPham.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int id);

        IEnumerable<T> DeleteMulti(Expression<Func<T, bool>> where);

        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        //phan trang
        //IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        //IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
