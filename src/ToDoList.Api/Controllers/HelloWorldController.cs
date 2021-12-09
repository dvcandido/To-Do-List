using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            
            var mensage = "Hello World Douglas";

            return Ok(mensage);
        }
    }
}