using AutoMapper;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Exceptions;
using DotNet.ApplicationCore.Utils;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Services.Repositories
{
    // IGenericRepository<Product>,
    public class ProductRepository : IProductRepository
    {
        private readonly DotNetContext storeContext;
        //  private readonly IMapper mapper;


        public ProductRepository(DotNetContext storeContext) //: base(storeContext)
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