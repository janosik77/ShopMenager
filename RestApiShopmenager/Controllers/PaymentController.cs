using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // Pobieramy płatności wraz z powiązaniami
            var payments = await _context.Payments
                .Include(p => p.Order)
                    .ThenInclude(o => o.Customer)
                .Include(p => p.PaymentMethod)
                // .Include(p => p.PaymentStatus) // jeśli chcesz wczytywać status
                .ToListAsync();

            // Mapujemy encje na DTO
            var result = payments.Select(p => new PaymentDto
            {
                PaymentID = p.PaymentID,
                OrderID = p.OrderID,
                CustomerID = p.Order?.CustomerID ?? 0,
                CustomerName = p.Order?.Customer?.FirstName + " " + p.Order?.Customer.LastName ?? "",
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethodID = p.PaymentMethodId.ToString(),
                PaymentMethodName = p.PaymentMethod?.MethodName ?? "",
                // PaymentStatus? => Można dopisać, jeśli chcesz w DTO
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
                .FirstOrDefaultAsync(p => p.PaymentID == id);

            if (payment == null)
            {
                return NotFound();
            }

            // Mapa encja -> DTO
            var dto = new PaymentDto
            {
                PaymentID = payment.PaymentID,
                OrderID = payment.OrderID,
                CustomerID = payment.Order?.CustomerID ?? 0,
                CustomerName = payment.Order?.Customer?.FirstName + " " + payment.Order?.Customer.LastName ?? "",
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethodID = payment.PaymentMethodId.ToString(),
                PaymentMethodName = payment.PaymentMethod?.MethodName ?? "",
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

            // Mapowanie DTO -> encja
            payment.OrderID = dto.OrderID;
            payment.PaymentDate = dto.PaymentDate;
            payment.Amount = dto.Amount;
            payment.PaymentMethodId = int.Parse(dto.PaymentMethodID);

            // Losowanie PaymentStatus (1..3)
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
            // Tworzymy nową encję
            var payment = new Payments
            {
                OrderID = dto.OrderID,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMethodId = int.Parse(dto.PaymentMethodID),
                PaymentStatusId = new Random().Next(1, 4) // losowo 1-3
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            // Po zapisaniu do bazy możemy wczytać powiązania, by uzupełnić Dto
            await _context.Entry(payment).Reference(p => p.Order).LoadAsync();
            await _context.Entry(payment).Reference(p => p.PaymentMethod).LoadAsync();
            // i ewentualnie wczytać Customer
            if (payment.Order != null)
            {
                await _context.Entry(payment.Order).Reference(o => o.Customer).LoadAsync();
            }

            // Mapujemy z powrotem do DTO, aby zwrócić aktualne dane
            var resultDto = new PaymentDto
            {
                PaymentID = payment.PaymentID,
                OrderID = payment.OrderID,
                CustomerID = payment.Order?.CustomerID ?? 0,
                CustomerName = payment.Order?.Customer?.FirstName ?? "",
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethodID = payment.PaymentMethodId.ToString(),
                PaymentMethodName = payment.PaymentMethod?.MethodName ?? "",
            };

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentID }, resultDto);
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
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
