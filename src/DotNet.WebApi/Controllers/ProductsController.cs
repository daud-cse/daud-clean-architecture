using Microsoft.AspNetCore.Mvc;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces;

namespace DotNet.WebApi.Controllers
{
    [Authorize]
    [Route("api/Products")]
    [ApiController]
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }       
        //[HttpGet, AllowAnonymous]

        //public ActionResult<List<ProductResponse>> GetProducts()
        //{           
        //    return Ok(this._productService.GetAllProducts());
        //}

        //[HttpGet("{id}")]
        //public ActionResult GetProductById(int id)
        //{
        //    try
        //    {
        //        var product = this._productService.GetProductById(id);
        //        return Ok(product);
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(Product request)
        //{
        //    var product = this._productService.CreateProduct(request);
        //    return Ok(product);
        //}

        //[HttpPut("{id}")]
        //public ActionResult Update(int id, Product request)
        //{
        //    try
        //    {
        //        var product = this._productService.UpdateProduct(request);
        //        return Ok(product);
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        this._productService.DeleteProduct(id);
        //        return NoContent();
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}