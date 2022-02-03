


namespace MaturaBg.Features
{
    using Microsoft.AspNetCore.Mvc;
    
    
    [ApiController]
    [Route("[controller]")]
    public abstract  class ApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("It Works");
        }
    }
}
