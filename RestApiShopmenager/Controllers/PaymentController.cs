using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;


namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PaymentController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
        {
            var payments = await _context.Payments
                .Include(p => p.Order)
                    .ThenInclude(o => o.Customer)
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .ToListAsync();

            var result = payments.Select(p => new PaymentDto
            {
                PaymentID = p.PaymentId,
                OrderID = p.OrderId,
                CustomerID = p.Order?.CustomerId ?? 0,
                CustomerName = (p.Order?.Customer?.FirstName ?? "") + " " + (p.Order?.Customer?.LastName ?? ""),
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethodID = p.PaymentMethodId, // int
                PaymentMethodName = p.PaymentMethod?.MethodName ?? "",
                PaymentStatusID = p.PaymentStatusId,
                PaymentStatusName = p.PaymentStatus?.StatusName ?? ""
            }).ToList();

            return Ok(result);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Order)
                    .ThenInclude(o => o.Customer)
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .FirstOrDefaultAsync(p => p.PaymentId == id);

            if (payment == null)
            {
                return NotFound();
            }

            // Mapowanie Entity -> DTO
            var dto = new PaymentDto
            {
                PaymentID = payment.PaymentId,
                OrderID = payment.OrderId,
                CustomerID = payment.Order?.CustomerId ?? 0,
                CustomerName = (payment.Order?.Customer?.FirstName ?? "") + " " + (payment.Order?.Customer?.LastName ?? ""),
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethodID = payment.PaymentMethodId,
                PaymentMethodName = payment.PaymentMethod?.MethodName ?? "",
                PaymentStatusID = payment.PaymentStatusId,
                PaymentStatusName = payment.PaymentStatus?.StatusName ?? ""
            };

            return Ok(dto);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, PaymentDto dto)
        {
            if (id != dto.PaymentID)
            {
                return BadRequest("ID in path and DTO do not match.");
            }

            // Znajdź istniejącą encję w bazie
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            // Mapowanie DTO -> Entity
            payment.OrderId = dto.OrderID;
            payment.PaymentDate = dto.PaymentDate;
            payment.Amount = dto.Amount;
            payment.PaymentMethodId = dto.PaymentMethodID; // int, bez parsowania

            // Losowanie PaymentStatusId (1..3)
            payment.PaymentStatusId = new Random().Next(1, 4);

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> PostPayment(PaymentDto dto)
        {
            // Tworzymy nową encję na podstawie DTO
            var payment = new Payments
            {
                OrderId = dto.OrderID,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethodId = dto.PaymentMethodID,
                PaymentStatusId = new Random().Next(1, 4) // losowo 1-3
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            // Po zapisaniu, ładujemy powiązane dane
            await _context.Entry(payment).Reference(p => p.Order).LoadAsync();
            await _context.Entry(payment).Reference(p => p.PaymentMethod).LoadAsync();
            await _context.Entry(payment).Reference(p => p.PaymentStatus).LoadAsync();
            if (payment.Order != null)
            {
                await _context.Entry(payment.Order).Reference(o => o.Customer).LoadAsync();
            }

            // Mapowanie do DTO
            var resultDto = new PaymentDto
            {
                PaymentID = payment.PaymentId,
                OrderID = payment.OrderId,
                CustomerID = payment.Order?.CustomerId ?? 0,
                CustomerName = (payment.Order?.Customer?.FirstName ?? "") + " " + (payment.Order?.Customer?.LastName ?? ""),
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethodID = payment.PaymentMethodId,
                PaymentMethodName = payment.PaymentMethod?.MethodName ?? "",
                PaymentStatusID = payment.PaymentStatusId,
                PaymentStatusName = payment.PaymentStatus?.StatusName ?? ""
            };

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, resultDto);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}
