using DotNet.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        int Save();
    }
}
