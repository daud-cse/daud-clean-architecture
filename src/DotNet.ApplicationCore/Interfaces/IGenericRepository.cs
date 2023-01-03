using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<T> GetByID(int id);
        //Task<IEnumerable<T>> GetAll();
        //Task Add(T entity);
        //void Delete(T entity);
        //void Update(T entity);
    }
}
