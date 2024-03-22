using CallApiweb.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallApiweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DtddContext _context;

        public ProductController(DtddContext context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }
        // GET: api/Products/5
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return ItemToDTO(Product);
        }
        // </snippet_GetByID>

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            Product.Name = todoDTO.Name;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProductExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // </snippet_Update>

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product todoDTO)
        {
            var Product = new Product
            {
                
                Name = todoDTO.Name
            };

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = Product.Id },
                ItemToDTO(Product));
        }
        // </snippet_Create>

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private static Product ItemToDTO(Product Product) =>
           new Product
           {
               Id = Product.Id,
               Name = Product.Name,
               
           };
    }
}
