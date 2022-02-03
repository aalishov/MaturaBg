

namespace MaturaBg.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    
   
    public class HomeApiController : ApiController
    {
        [HttpGet]
        [Route(nameof(Get))]
        [Authorize]
        public IActionResult Get()
        {
            
            return Ok("Ohhooo its my first action");
        }

     

    }
}
