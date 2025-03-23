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
    public class DiscountController : ControllerBase
    {
        private readonly CompanyContext _context;

        public DiscountController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Discount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discounts>>> GetDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }

        // GET: api/Discount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discounts>> GetDiscounts(int id)
        {
            var discounts = await _context.Discounts.FindAsync(id);

            if (discounts == null)
            {
                return NotFound();
            }

            return discounts;
        }

        // PUT: api/Discount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscounts(int id, Discounts discounts)
        {
            if (id != discounts.DiscountId)
            {
                return BadRequest();
            }

            _context.Entry(discounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountsExists(id))
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

        // POST: api/Discount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discounts>> PostDiscounts(Discounts discounts)
        {
            _context.Discounts.Add(discounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscounts", new { id = discounts.DiscountId }, discounts);
        }

        // DELETE: api/Discount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscounts(int id)
        {
            var discounts = await _context.Discounts.FindAsync(id);
            if (discounts == null)
            {
                return NotFound();
            }

            _context.Discounts.Remove(discounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscountsExists(int id)
        {
            return _context.Discounts.Any(e => e.DiscountId == id);
        }
    }
}
