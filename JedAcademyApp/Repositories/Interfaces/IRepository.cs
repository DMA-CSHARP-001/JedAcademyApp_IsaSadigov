using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Func<T, bool> expression);   
    }
}
