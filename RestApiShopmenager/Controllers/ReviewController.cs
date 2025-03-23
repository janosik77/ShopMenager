using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // Pobieramy wszystkie recenzje wraz z powiązanymi Employee i Product
            var reviews = await _context.Reviews
                .Include(r => r.Employee)
                .Include(r => r.Product)
                .ToListAsync();

            // Mapowanie Entity → DTO
            var reviewsDto = reviews.Select(r => new ReviewsDto
            {
                ReviewId = r.ReviewId,
                Rating = r.Rating,
                Comments = r.Comments,
                ReviewDate = r.ReviewDate,
                Employee = new EmployeeDto
                {
                    EmployeeID = r.Employee.EmployeeId,
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Email = r.Employee.Email,
                    Phone = r.Employee.Phone,
                    PhotoPath = r.Employee.PhotoPath
                },
                Product = new ProductDto
                {
                    ProductID = r.Product.ProductId,
                    CategoryID = r.Product.CategoryId,
                    ProductName = r.Product.ProductName,
                    Price = r.Product.Price,
                    Stock = r.Product.Stock,
                    Description = r.Product.Description,
                    PhotoPath = r.Product.PhotoPath

                }
            }).ToList();

            return Ok(reviewsDto);
        }

        //// GET: api/Review/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ReviewsDto>> GetReview(int id)
        //{
        //    var review = await _context.Reviews
        //        .Include(r => r.Employee)
        //        .Include(r => r.Product)
        //        .FirstOrDefaultAsync(r => r.ReviewId == id);

        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    // Mapowanie Entity → DTO
        //    var reviewDto = new ReviewsDto
        //    {
        //        ReviewId = review.ReviewId,
        //        Rating = review.Rating,
        //        Comments = review.Comments,
        //        ReviewDate = review.ReviewDate,
        //        Employee = new EmployeeDto
        //        {
        //            EmployeeID = review.Employee.EmployeeId,
        //            // ... inne pola ...
        //        },
        //        Product = new ProductDto
        //        {
        //            ProductID = review.Product.ProductId,
        //            // ... inne pola ...
        //        }
        //    };

        //    return Ok(reviewDto);
        //}

        //// PUT: api/Review/5
        //// Uaktualnienie istniejącej recenzji
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReview(int id, ReviewsDto reviewDto)
        //{
        //    if (id != reviewDto.ReviewId)
        //    {
        //        return BadRequest("Mismatched ReviewId");
        //    }

        //    // Szukamy w bazie recenzji o danym ID
        //    var review = await _context.Reviews.FindAsync(id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    // Mapowanie DTO → Entity
        //    review.Rating = reviewDto.Rating;
        //    review.Comments = reviewDto.Comments;
        //    review.ReviewDate = reviewDto.ReviewDate;

        //    // Zakładamy, że w Review jest pole EmployeeId / ProductId
        //    // (lub przypisujesz obiekty Employee / Product, jeżeli tak jest skonfigurowany model)
        //    review.Employee.EmployeeId = reviewDto.Employee.EmployeeID;
        //    review.ProductId = reviewDto.Product.ProductID;

        //    _context.Entry(review).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReviewsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Review
        //// Dodanie nowej recenzji
        //[HttpPost]
        //public async Task<ActionResult<ReviewsDto>> PostReview(ReviewsDto reviewDto)
        //{
        //    // Mapowanie DTO → Entity
        //    var review = new Reviews
        //    {
        //        Rating = reviewDto.Rating,
        //        Comments = reviewDto.Comments,
        //        ReviewDate = reviewDto.ReviewDate,
        //        EmployeeId = reviewDto.Employee.EmployeeID,
        //        ProductId = reviewDto.Product.ProductID
        //    };

        //    _context.Reviews.Add(review);
        //    await _context.SaveChangesAsync();

        //    // Po zapisaniu w bazie mamy nowy ReviewId
        //    reviewDto.ReviewId = review.ReviewId;

        //    // Zwracamy utworzony obiekt w formie DTO
        //    return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, reviewDto);
        //}

        //// DELETE: api/Review/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReview(int id)
        //{
        //    var review = await _context.Reviews.FindAsync(id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reviews.Remove(review);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ReviewsExists(int id)
        //{
        //    return _context.Reviews.Any(e => e.ReviewId == id);
        //}
    }
}
