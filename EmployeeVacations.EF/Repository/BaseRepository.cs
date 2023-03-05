using EmployeeVacations.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVacations.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dataContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
