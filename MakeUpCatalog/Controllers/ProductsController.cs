using MakeupCatalog.Model;
using Microsoft.AspNetCore.Mvc;
using Repo.MakeupCatalog;
using System;
using System.Collections.Generic;
using Domain.MakeupCatalog;

namespace MakeupCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProductsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAllProducts()
        {
            try
            {
                var result = _repo.GetAllProducts(true);
                List<ProductModel> productModelList = new List<ProductModel>();
                foreach (var p in result)
                {
                    ProductModel product = new ProductModel();
                    product.ProductId = p.ProductId;
                    product.Name = p.Name;
                    product.Color = p.Color;
                    product.Brand = p.Brand;
                    product.Price = p.Price;
                    product.Description = p.Description;
                    product.MakeupTypeId = p.MakeupTypeId;
                    productModelList.Add(product);
                }

                return productModelList;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _repo.GetProductById(id, false);
                if (product == null)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductModel product)
        {
            try
            {
                _repo.Add( new Product() 
                {
                    Name = product.Name,
                    Brand = product.Brand,
                    Color = product.Color,
                    Price = product.Price,
                    Description = product.Description,
                    //MakeupType = product.MakeupType,
                    MakeupTypeId = product.MakeupTypeId
                });

                _repo.SaveChanges(product);

                new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
                return Ok("Ok.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] ProductModel product)
        {
            try
            {             
                var productFromDb = _repo.GetProductById(id, false);
                if (productFromDb == null)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                productFromDb.Name = product.Name;
                productFromDb.Brand = product.Brand;
                productFromDb.Color = product.Color;
                productFromDb.Price = product.Price;
                productFromDb.Description = product.Description;
                //productFromDb.MakeupType = product.MakeupType;
                productFromDb.MakeupTypeId = product.MakeupTypeId;
                
                _repo.Update(productFromDb);    

                _repo.SaveChanges(product);
                return Ok($"The product id={id} has been update successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _repo.GetProductById(id, false);
                if (product == null)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                _repo.Delete(product);
                _repo.SaveChanges(product);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}