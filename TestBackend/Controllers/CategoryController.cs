using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBackend.Models;
using TestBackend.Models.Repository;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly TestContext testContext;

        public CategoryController(TestContext context)
        {
            testContext = context;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(testContext.Categories);
        }
    }
}