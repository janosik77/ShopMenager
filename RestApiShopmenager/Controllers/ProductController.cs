using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ProductController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            // Eager loading kategorii, by mieć CategoryName
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            // Mapowanie encji -> DTO
            var dtos = products.Select(p => new ProductDto
            {
                ProductID = p.ProductId,
                CategoryID = p.CategoryId,
                CategoryName = p.Category != null
                    ? p.Category.CategoryName
                    : "N/A",
                ProductName = p.ProductName,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description,
                PhotoPath = p.PhotoPath
            });

            return Ok(dtos);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            // Znajdujemy produkt z wczytaniem kategorii
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Mapowanie encji -> DTO
            var dto = new ProductDto
            {
                ProductID = product.ProductId,
                CategoryID = product.CategoryId,
                CategoryName = product.Category?.CategoryName ?? "N/A",
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                PhotoPath = product.PhotoPath
            };

            return Ok(dto);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto dto)
        {
            if (id != dto.ProductID)
            {
                return BadRequest("ID w URL i DTO nie są zgodne.");
            }

            // Szukamy encji w bazie
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Mapowanie DTO -> encja
            product.CategoryId = dto.CategoryID;
            product.ProductName = dto.ProductName;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Description = dto.Description;
            product.PhotoPath = dto.PhotoPath;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto dto)
        {
            // Tworzymy encję i mapujemy z DTO
            var product = new Products
            {
                CategoryId = dto.CategoryID,
                ProductName = dto.ProductName,
                Price = dto.Price,
                Stock = dto.Stock,
                Description = dto.Description,
                PhotoPath = dto.PhotoPath
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Odczytujemy klucz wygenerowany w bazie
            // Możemy też dołączyć CategoryName, ale trzeba by wczytać encję
            var createdDto = new ProductDto
            {
                ProductID = product.ProductId,
                CategoryID = product.ProductId,
                CategoryName = "N/A", // Ewentualnie wczytać ponownie
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                PhotoPath = product.PhotoPath
            };

            // Zwracamy 201 Created
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, createdDto);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
