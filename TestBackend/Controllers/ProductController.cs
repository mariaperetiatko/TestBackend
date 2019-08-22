using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBackend.Models;
using TestBackend.Models.Repository;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IDataRepository<Product> productDB;

        public ProductController(IDataRepository<Product> dataRepository)
        {
            productDB = dataRepository;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public IActionResult GetAllProducts()
        {
            IEnumerable<Product> products = productDB.GetEntitySet();
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(long id)
        {
            Product product = productDB.GetEntity(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            return Ok(product);
        }

        [HttpGet("GetProductsByName/{name}")]
        public IActionResult GetProductsByName(string name)
        {
            IEnumerable<Product> products = productDB.SearchByField(name);                
            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            productDB.Create(product);
            return Ok(product);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            productDB.Update(product);
            return Ok(product);
        }
       
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteBuilding(int id)
        {
            Product product = productDB.GetEntity(id);
            if (product == null)
            {
                return NotFound("Product couldn't be found");
            }
            productDB.Delete(product);
            return Ok(product);
        }
    }
}