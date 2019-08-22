using Microsoft.AspNetCore.Mvc;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Backend works";
        }        
    }
}
