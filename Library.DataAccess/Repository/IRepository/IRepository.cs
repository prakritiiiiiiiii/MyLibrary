using Library.Models;
using System.Linq.Expressions;

namespace Library.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T-Category
        //IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T Get(Expression<Func<T, bool>>filter);
        void Add(T entity);  
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

        void Save();
        void Update(Category obj);


    }
}
