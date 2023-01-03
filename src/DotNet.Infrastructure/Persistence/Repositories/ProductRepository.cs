using AutoMapper;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Exceptions;
using DotNet.ApplicationCore.Interfaces;
using DotNet.ApplicationCore.Utils;
using DotNet.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DotNetContext storeContext;
      //  private readonly IMapper mapper;

        public ProductRepository(DotNetContext storeContext):base(storeContext)
        {
            this.storeContext = storeContext;
            //this.mapper = mapper;
        }

        public object DeleteProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}