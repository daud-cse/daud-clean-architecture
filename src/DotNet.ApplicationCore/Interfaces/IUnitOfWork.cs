using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Save();
    }
}
