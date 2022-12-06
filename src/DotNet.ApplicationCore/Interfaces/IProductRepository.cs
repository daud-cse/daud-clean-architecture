using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using System.Collections.Generic;

namespace DotNet.ApplicationCore.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
     //   List<ProductResponse> GetProducts();

       // ProductResponse GetProductById(int productId);

        //void DeleteProductById(int productId);

       // ProductResponse CreateProduct(CreateProductRequest request);

       // ProductResponse UpdateProduct(int productId, UpdateProductRequest request);
    }
}