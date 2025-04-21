using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CompanyContext _context;

        public EmployeeController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var result = employees.Select(e => MapToDto(e)).ToList();
            return Ok(result);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return MapToDto(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(EmployeeDto dto)
        {
            // Mapowanie DTO -> encja
            var employee = new Employees
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                HireDate = (dto.HireDate == default)
                    ? null
                    : dto.HireDate,
                Salary = dto.Salary,
                PhotoPath = dto.PhotoPath
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // Wczytujemy dane z bazy, np. ID
            // Mapujemy z powrotem do DTO
            var resultDto = MapToDto(employee);

            // Zwracamy 201 (Created) z nowym ID
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, resultDto);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDto dto)
        {
            if (id != dto.EmployeeID)
            {
                return BadRequest("Employee ID in path does not match DTO");
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Phone = dto.Phone;
            employee.HireDate = (dto.HireDate == default)
                ? null
                : dto.HireDate;
            employee.Salary = dto.Salary;
            employee.PhotoPath = dto.PhotoPath;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        // ─────────────────────────────────────────────────────────
        // Mapowanie encja -> DTO
        // ─────────────────────────────────────────────────────────
        private EmployeeDto MapToDto(Employees e)
        {
            // Konwersja z DateOnly? na DateTime
            var hireDate = e.HireDate.HasValue
                ? new DateOnly(e.HireDate.Value.Year, e.HireDate.Value.Month, e.HireDate.Value.Day)
                : default;

            return new EmployeeDto
            {
                EmployeeID = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email ?? "",
                Phone = e.Phone ?? "",
                HireDate = hireDate,
                Salary = e.Salary ?? 0, // 0 jeśli null w bazie
                PhotoPath = e.PhotoPath ?? ""
            };
        }
    }
}
