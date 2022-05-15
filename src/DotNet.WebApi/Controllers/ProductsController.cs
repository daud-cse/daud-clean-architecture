using Microsoft.AspNetCore.Mvc;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Exceptions;
using DotNet.ApplicationCore.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace DotNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductResponse>> GetProducts()
        {
           var userName= User.Identity.Name;
            return Ok(this.productRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = this.productRepository.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(CreateProductRequest request)
        {
            var product = this.productRepository.CreateProduct(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateProductRequest request)
        {
            try
            {
                var product = this.productRepository.UpdateProduct(id, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.productRepository.DeleteProductById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}