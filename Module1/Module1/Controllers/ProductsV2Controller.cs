using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;

namespace Module1.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsV2Controller : ControllerBase
    {
        private ProductsDbContext _productsDbContext;
        public ProductsV2Controller(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get(int? pageNumber, int? pageSize)
        {
            try
            {
                var products = from p in _productsDbContext.Products.OrderBy(p => p.Id) select p;
                int currentPage = pageNumber ?? 1;
                int currentPageSize = pageSize ?? 5;

                var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productsDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("No Record Found...");
            }
            else {
                return Ok(product);
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductV2 product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else {
                _productsDbContext.Products.Add(product);
                _productsDbContext.SaveChanges(true);
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductV2 product)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != product.Id) {
                return BadRequest();
            }
            try
            {
                _productsDbContext.Products.Update(product);
                _productsDbContext.SaveChanges(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                NotFound("No Record found againt this Id");
            }
            return Ok("Product Updated...");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productsDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("No Record Found...");
            }
            _productsDbContext.Products.Remove(product);
            _productsDbContext.SaveChanges(true);
            return Ok("Product Deleted...");
        }
    }
}
