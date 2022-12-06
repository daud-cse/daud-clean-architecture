using DotNet.ApplicationCore.Interfaces;
using DotNet.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Infrastructure.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DotNetContext _dotnetContext;

        protected GenericRepository(DotNetContext dotnetContext)
        {
            this._dotnetContext = dotnetContext;
        }
        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
