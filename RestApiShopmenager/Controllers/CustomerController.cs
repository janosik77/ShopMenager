using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts; // <-- Zależnie od Twojej struktury projektu

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CustomersController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            var result = customers.Select(c => MapToDto(c)).ToList();
            return Ok(result);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return MapToDto(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto dto)
        {
            // Mapowanie DTO -> encja
            var customer = new Customers
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = string.IsNullOrEmpty(dto.Phone) ? null : dto.Phone,
                Address = string.IsNullOrEmpty(dto.Address) ? null : dto.Address,
                City = string.IsNullOrEmpty(dto.City) ? null : dto.City,
                PhotoPath = string.IsNullOrEmpty(dto.PhotoPath) ? null : dto.PhotoPath
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Mapujemy z powrotem do DTO, aby zwrócić np. nowy CustomerId
            var resultDto = MapToDto(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, resultDto);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto dto)
        {
            if (id != dto.CustomerId)
            {
                return BadRequest("Customer ID in path does not match DTO");
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = string.IsNullOrEmpty(dto.Phone) ? null : dto.Phone;
            customer.Address = string.IsNullOrEmpty(dto.Address) ? null : dto.Address;
            customer.City = string.IsNullOrEmpty(dto.City) ? null : dto.City;
            customer.PhotoPath = string.IsNullOrEmpty(dto.PhotoPath) ? null : dto.PhotoPath;

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        // ─────────────────────────────────────────────────────────
        // Mapowanie encja -> DTO
        // ─────────────────────────────────────────────────────────
        private CustomerDto MapToDto(Customers c)
        {
            return new CustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone ?? "",    // 'required' w DTO, więc dajemy pusty string jeśli null
                Address = c.Address ?? "",
                City = c.City ?? "",
                PhotoPath = c.PhotoPath ?? ""
            };
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using RestApiShopmenager.Models;
//using RestApiShopmenager.Models.Contexts;

//namespace RestApiShopmenager.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly CompanyContext _context;

//        public CustomerController(CompanyContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Customer
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
//        {
//            return await _context.Customers.ToListAsync();
//        }

//        // GET: api/Customer/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Customers>> GetCustomers(int id)
//        {
//            var customers = await _context.Customers.FindAsync(id);

//            if (customers == null)
//            {
//                return NotFound();
//            }

//            return customers;
//        }

//        // PUT: api/Customer/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCustomers(int id, Customers customers)
//        {
//            if (id != customers.CustomerId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(customers).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CustomersExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Customer
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
//        {
//            _context.Customers.Add(customers);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);
//        }

//        //DELETE: api/Customer/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCustomers(int id)
//        {
//            var customers = await _context.Customers.FindAsync(id);
//            if (customers == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customers);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool CustomersExists(int id)
//        {
//            return _context.Customers.Any(e => e.CustomerId == id);
//        }
//    }
//}
