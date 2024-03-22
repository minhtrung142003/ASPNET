using haminhtrung.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace haminhtrung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DtddContext _context;

        public ProductController(DtddContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public IActionResult GetAll() { 
            return Ok(_context.Products.ToList());
        }
    }
}
