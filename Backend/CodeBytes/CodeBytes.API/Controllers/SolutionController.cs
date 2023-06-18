using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBytes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolutionController : Controller
    {
        [HttpPost]
        public ActionResult Solution(IFormCollection collection)
        {
            return Ok();
        }
    }
}
