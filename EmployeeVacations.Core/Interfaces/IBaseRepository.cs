using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVacations.Core.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Delete(int id);
        Task<T> Update(T entity);
    }
}
