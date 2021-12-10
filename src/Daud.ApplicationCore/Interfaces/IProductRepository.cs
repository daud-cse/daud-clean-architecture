﻿using Daud.ApplicationCore.DTOs;
using System.Collections.Generic;

namespace Daud.ApplicationCore.Interfaces
{
    public interface IProductRepository
    {
        List<ProductResponse> GetProducts();

        ProductResponse GetProductById(int productId);

        void DeleteProductById(int productId);

        ProductResponse CreateProduct(CreateProductRequest request);

        ProductResponse UpdateProduct(int productId, UpdateProductRequest request);
    }
}