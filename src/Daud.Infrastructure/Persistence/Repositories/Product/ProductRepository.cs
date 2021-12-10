using AutoMapper;
using Daud.ApplicationCore.DTOs;
using Daud.ApplicationCore.Entities;
using Daud.ApplicationCore.Exceptions;
using Daud.ApplicationCore.Interfaces;
using Daud.ApplicationCore.Utils;
using Daud.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Daud.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DaudContext storeContext;
        private readonly IMapper mapper;

        public ProductRepository(DaudContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }

        public ProductResponse CreateProduct(CreateProductRequest request)
        {
            var product = this.mapper.Map<Product>(request);
            product.Stock = 0;
            product.CreatedAt = product.UpdatedAt = DateUtil.GetCurrentDate();

            this.storeContext.Products.Add(product);
            this.storeContext.SaveChanges();

            return this.mapper.Map<ProductResponse>(product);
        }

        public void DeleteProductById(int productId)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                this.storeContext.Products.Remove(product);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public ProductResponse GetProductById(int productId)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                return this.mapper.Map<ProductResponse>(product);
            }

            throw new NotFoundException();
        }

        public List<ProductResponse> GetProducts()
        {
            return this.storeContext.Products.Select(p => this.mapper.Map<ProductResponse>(p)).ToList();
        }

        public ProductResponse UpdateProduct(int productId, UpdateProductRequest request)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.UpdatedAt = DateUtil.GetCurrentDate();

                this.storeContext.Products.Update(product);
                this.storeContext.SaveChanges();

                return this.mapper.Map<ProductResponse>(product);
            }

            throw new NotFoundException();
        }
    }
}