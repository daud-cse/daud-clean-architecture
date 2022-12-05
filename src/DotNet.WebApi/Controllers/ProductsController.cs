//using Microsoft.AspNetCore.Mvc;
//using DotNet.ApplicationCore.DTOs;
//using DotNet.ApplicationCore.Exceptions;
//using DotNet.ApplicationCore.Interfaces;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Authorization;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DotNet.WebApi.Controllers
//{
//    [Authorize]
//    [Route("api/Products")]
//    [ApiController]
//    //[Authorize]
//    public class ProductsController : Controller
//    {
//        private readonly IProductRepository productRepository;

//        public ProductsController(IProductRepository productRepository)
//        {
//            this.productRepository = productRepository;
//        }



//        protected async Task<int> GetCompanyIdFromClaimAsync()
//        {
//            var principal = this.HttpContext.User;
//            if (principal == null) throw new Exception("Orginzation not found");
//            var claims = principal.Claims.ToList();
//            var companyId = claims.FirstOrDefault(c => c.Type == "OrginzationId")?.Value;
//            return await System.Threading.Tasks.Task.FromResult(Convert.ToInt32(companyId));
//        }
//        protected int GetCompanyIdFromClaim()
//        {
//            var principal = this.HttpContext.User;
//            if (principal == null) throw new Exception("Orginzation not found");
//            var claims = principal.Claims.ToList();
//            var companyId = claims.FirstOrDefault(c => c.Type == "OrginzationId")?.Value;
//            return Convert.ToInt32(companyId);
//        }
//        protected string GetUserIdFromClaim()
//        {
//            var principal = this.HttpContext.User;
//            if (principal == null) throw new Exception("UserId not found");
//            var claims = principal.Claims.ToList();
//            var companyId = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
//            return Convert.ToString(companyId);
//        }
//        [HttpGet]
       
//        public ActionResult<List<ProductResponse>> GetProducts()
//        {
//           //var userName= User.Identity.Name;
//          var orgId=  GetCompanyIdFromClaim();
//            var userId = GetUserIdFromClaim();
//            //var OrginzationId = User.Identities.
//            return Ok(this.productRepository.GetProducts());
//        }

//        [HttpGet("{id}")]
//        public ActionResult GetProductById(int id)
//        {
//            try
//            {
//                var product = this.productRepository.GetProductById(id);
//                return Ok(product);
//            }
//            catch (NotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpPost]
//        public ActionResult Create(CreateProductRequest request)
//        {
//            var product = this.productRepository.CreateProduct(request);
//            return Ok(product);
//        }

//        [HttpPut("{id}")]
//        public ActionResult Update(int id, UpdateProductRequest request)
//        {
//            try
//            {
//                var product = this.productRepository.UpdateProduct(id, request);
//                return Ok(product);
//            }
//            catch (NotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                this.productRepository.DeleteProductById(id);
//                return NoContent();
//            }
//            catch (NotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}