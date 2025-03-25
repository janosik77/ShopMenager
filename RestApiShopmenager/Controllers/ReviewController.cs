using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ReviewController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewsDto>>> GetReviews()
        {
            var reviews = await _context.Reviews
                .Include(r => r.Employee)
                .Include(r => r.Product)
                .ToListAsync();

            var dtos = reviews.Select(r => new ReviewsDto
            {
                ReviewID = r.ReviewId,
                Rating = r.Rating,
                Comments = r.Comments,
                ReviewDate = r.ReviewDate,
                EmployeeID = r.EmployeeID,
                ProductID = r.ProductId,
                EmployeeName = r.Employee != null
                    ? $"{r.Employee.FirstName} {r.Employee.LastName}"
                    : "N/A",
                ProductName = r.Product != null
                    ? r.Product.ProductName
                    : "N/A"
            });

            return Ok(dtos);
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsDto>> GetReviews(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Employee)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(r => r.ReviewId == id);

            if (review == null)
            {
                return NotFound();
            }

            var dto = new ReviewsDto
            {
                ReviewID = review.ReviewId,
                Rating = review.Rating,
                Comments = review.Comments,
                ReviewDate = review.ReviewDate,
                EmployeeID = review.EmployeeID,
                ProductID = review.ProductId,
                EmployeeName = review.Employee != null
                    ? review.Employee.FirstName + " " + review.Employee.LastName
                    : "N/A",
                ProductName = review.Product != null
                    ? review.Product.ProductName
                    : "N/A"
            };
            return Ok(dto);
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviews(int id, ReviewsDto dto)
        {
            if (id != dto.ReviewID)
            {
                // Możesz zwrócić błąd, jeśli chcemy spójności ID w URL i DTO
                return BadRequest("ID in URL and DTO do not match.");
            }

            // Sprawdzamy, czy taki rekord istnieje
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            // Aktualizujemy pola na podstawie DTO
            review.Rating = dto.Rating;
            review.Comments = dto.Comments;
            review.ReviewDate = dto.ReviewDate;
            review.EmployeeID = dto.EmployeeID;
            review.ProductId = dto.ProductID;

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // ponownie rzucamy wyjątek
                }
            }

            return NoContent();
        }

        // POST: api/Review
        [HttpPost]
        public async Task<ActionResult<ReviewsDto>> PostReviews(ReviewsDto dto)
        {
            // Tworzymy nowy obiekt encji
            var review = new Reviews
            {
                Rating = dto.Rating,
                Comments = dto.Comments,
                ReviewDate = dto.ReviewDate,
                EmployeeID = dto.EmployeeID,
                ProductId = dto.ProductID
                // ReviewId jest nadawane przez bazę (Identity)
            };

            // Dodajemy do kontekstu i zapisujemy
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            // Odczytujemy dane utworzonego rekordu (np. klucz ReviewId)
            // i zwracamy zmapowane na DTO
            var createdDto = new ReviewsDto
            {
                ReviewID = review.ReviewId,
                Rating = review.Rating,
                Comments = review.Comments,
                ReviewDate = review.ReviewDate,
                EmployeeID = review.EmployeeID,
                ProductID = review.ProductId,
                // Możemy dołączyć Employee/Product, ale wymagałoby eager loadingu; 
                //   w tym przykładzie zwrócimy je puste lub "N/A".
                EmployeeName = "N/A",
                ProductName = "N/A"
            };

            // Zwracamy 201 Created z nowym zasobem
            return CreatedAtAction(nameof(GetReviews), new { id = review.ReviewId }, createdDto);
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviews(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(r => r.ReviewId == id);
        }
    }
}
