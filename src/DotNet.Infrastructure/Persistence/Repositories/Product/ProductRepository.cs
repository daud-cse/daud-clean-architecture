using AutoMapper;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Exceptions;
using DotNet.ApplicationCore.Interfaces;
using DotNet.ApplicationCore.Utils;
using DotNet.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DotNetContext storeContext;
      //  private readonly IMapper mapper;

        public ProductRepository(DotNetContext storeContext
           // , IMapper mapper
            ):base(storeContext)
        {
            this.storeContext = storeContext;
           // this.mapper = mapper;
        }      
    }
}