using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatusController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PaymentStatusController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/PaymentStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentStatuses>>> GetPaymentStatuses()
        {
            return await _context.PaymentStatuses.ToListAsync();
        }

        // GET: api/PaymentStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentStatuses>> GetPaymentStatuses(int id)
        {
            var paymentStatuses = await _context.PaymentStatuses.FindAsync(id);

            if (paymentStatuses == null)
            {
                return NotFound();
            }

            return paymentStatuses;
        }

        // PUT: api/PaymentStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentStatuses(int id, PaymentStatuses paymentStatuses)
        {
            if (id != paymentStatuses.PaymentStatusId)
            {
                return BadRequest();
            }

            _context.Entry(paymentStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentStatusesExists(id))
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

        // POST: api/PaymentStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentStatuses>> PostPaymentStatuses(PaymentStatuses paymentStatuses)
        {
            _context.PaymentStatuses.Add(paymentStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentStatuses", new { id = paymentStatuses.PaymentStatusId }, paymentStatuses);
        }

        // DELETE: api/PaymentStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentStatuses(int id)
        {
            var paymentStatuses = await _context.PaymentStatuses.FindAsync(id);
            if (paymentStatuses == null)
            {
                return NotFound();
            }

            _context.PaymentStatuses.Remove(paymentStatuses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentStatusesExists(int id)
        {
            return _context.PaymentStatuses.Any(e => e.PaymentStatusId == id);
        }
    }
}
