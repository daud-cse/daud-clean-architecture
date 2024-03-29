﻿using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<bool> CreateProduct(Product productDetails)
        //{
        //    if (productDetails != null)
        //    {
        //        await _unitOfWork.Products.Add(productDetails);

        //        var result = _unitOfWork.Save();

        //        if (result > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    return false;
        //}

        //public async Task<bool> DeleteProduct(int productId)
        //{
        //    if (productId > 0)
        //    {
        //        var productDetails = await _unitOfWork.Products.GetById(productId);
        //        if (productDetails != null)
        //        {
        //            _unitOfWork.Products.Delete(productDetails);
        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}

        //public async Task<IEnumerable<Product>> GetAllProducts()
        //{
        //    var productDetailsList = await _unitOfWork.Products.GetAll();
        //    return productDetailsList;
        //}

        //public async Task<Product> GetProductById(int productId)
        //{
        //    if (productId > 0)
        //    {
        //        var productDetails = await _unitOfWork.Products.GetById(productId);
        //        if (productDetails != null)
        //        {
        //            return productDetails;
        //        }
        //    }
        //    return null;
        //}

        //public async Task<bool> UpdateProduct(Product productDetails)
        //{
        //    if (productDetails != null)
        //    {
        //        var product = await _unitOfWork.Products.GetById(productDetails.ProductId);
        //        if (product != null)
        //        {
        //            //product.ProductName = productDetails.ProductName;
        //            //product.ProductDescription = productDetails.ProductDescription;
        //           // product.ProductPrice = productDetails.ProductPrice;
        //           // product.ProductStock = productDetails.ProductStock;

        //            _unitOfWork.Products.Update(product);

        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}
    }
}
