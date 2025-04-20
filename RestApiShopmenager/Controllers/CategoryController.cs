using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts; // <-- Zależnie od Twojej struktury projektu
using RestApiShopmenager.DTOs;           // <-- Namespace, w którym masz CategoryDto

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CategoryController(CompanyContext context)
        { 
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var result = categories.Select(c => MapToDto(c)).ToList();
            return Ok(result);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return MapToDto(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto dto)
        {
            // Mapowanie DTO -> encja
            var category = new Categories
            {
                CategoryName = dto.CategoryName,
                CategoryDescription = dto.CategoryDescription
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Mapujemy z powrotem do DTO, by zwrócić np. nowy CategoryID
            var resultDto = MapToDto(category);

            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, resultDto);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto dto)
        {
            if (id != dto.CategoryID)
            {
                return BadRequest("Category ID in path does not match DTO");
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            category.CategoryName = dto.CategoryName;
            category.CategoryDescription = dto.CategoryDescription;

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

        // Mapowanie encja -> DTO
        private CategoryDto MapToDto(Categories c)
        {
            return new CategoryDto
            {
                CategoryID = c.CategoryId,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription
            };
        }
    }
}
