using Database.MakeupCatalog;
using Domain.MakeupCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.MakeupCatalog;

namespace MakeupCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProductsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            try
            {
                return await _context.ProductRepository.Get().ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _context.ProductRepository.GetById(p => p.ProductId == id);

                if (product == null)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                return product;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody]Product product)
        {
            try
            {
                _context.ProductRepository.Add(product);
                await _context.Commit();

                new CreatedAtRouteResult("GetProduct", 
                    new { id = product.ProductId }, product);
                return Ok("Ok.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                _context.ProductRepository.Update(product);
                await _context.Commit();
                return Ok($"The product id={id} has been update successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.ProductRepository.GetById(p => p.ProductId == id);
                if (product == null)
                {
                    return NotFound($"The product id={id} was not found.");
                }

                _context.ProductRepository.Delete(product);
                await _context.Commit();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}