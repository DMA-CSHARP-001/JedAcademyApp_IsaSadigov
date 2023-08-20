using JedAcademyApp.Entities;
using JedAcademyApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JedAcademyApp.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private static List<T> _items = new List<T>();
        public List<T> Items { get { return _items; } }
        public async Task AddAsync(T entity)
        {
            Items.Add(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            Items.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return Items;
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return  _items.FirstOrDefault(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (Items[i].Id == entity.Id)
                {
                    _items[i] = entity;
                }
            }
        }
    }
}
