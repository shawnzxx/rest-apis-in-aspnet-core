using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    //If uncomment will only return JSON format
    //[Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsV1Controller : ControllerBase
    {
        //static will cross all over the class, remove the static each time call the controller will create a new list
        static List<ProductV1> _products = new List<ProductV1>()
        {
            new ProductV1(){ ProductId = 0, ProductName = "Laptop", ProductPrice = "200"},
            new ProductV1(){ ProductId = 1, ProductName = "SmartPhone", ProductPrice = "100"}
        };
        
        //as long as method name have Get prefix will use https://hostname/products
        public IActionResult GetMyProducts() {
            //return Ok(_products);
            //return BadRequest();
            return StatusCode(StatusCodes.Status200OK, _products);
        }

        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            //return Ok(_products);
            //return BadRequest();
            return Ok("Welcome ...");
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductV1 product) {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{Id}")]
        public void Put(int id, [FromBody]ProductV1 product) {
            _products[id] = product;
        }

        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}