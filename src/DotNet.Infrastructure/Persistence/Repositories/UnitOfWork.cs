using DotNet.ApplicationCore.Interfaces;
using DotNet.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotNetContext _dotnetContext;
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(DotNetContext dotnetContext,
                            IProductRepository productRepository,
                            IUserRepository userRepository
            )
        {
            _dotnetContext = dotnetContext;
            Products = productRepository;
            Users = userRepository;
        }

        public int Save()
        {
            return _dotnetContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dotnetContext.Dispose();
            }
        }

    }
}
