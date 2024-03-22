using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using webcore.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public ContentResult Get()
        {
            List<Product> lstProduct = new List<Product>();
            Product objProduct = new Product();
            objProduct.Id = 1;
            objProduct.Name = "trà sữa";
            lstProduct.Add(objProduct);
            objProduct = new Product();
            objProduct.Id = 2;
            objProduct.Name = "Bánh Tráng Trộn";
            lstProduct.Add(objProduct);
            var json = JsonSerializer.Serialize(lstProduct);
            return Content(json, "application/json");
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
