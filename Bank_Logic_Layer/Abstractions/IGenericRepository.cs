using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Find(int id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        void Delete(int id);
        void Update(T entity);
        Task Commit();
        Task AddAndCommit(T entity);
        Task<List<T>> GetTableByExpession(Expression<Func<T, bool>> expression);

    }
}
