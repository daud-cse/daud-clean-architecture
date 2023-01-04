using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Repositories.Interfaces.Common;

namespace DotNet.Services.Repositories.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        int Save();
    }
}
