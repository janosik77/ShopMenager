using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts; // <-- Zależnie od Twojej struktury

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CompanyContext _context;

        public OrdersController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            // Ładujemy zamówienia wraz z powiązanymi encjami
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToListAsync();

            // Mapujemy encje na DTO
            var result = orders.Select(o => MapOrderToDto(o)).ToList();
            return Ok(result);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return MapOrderToDto(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto dto)
        {
            // Tworzymy encję Orders
            var order = new Orders
            {
                CustomerID = dto.CustomerID,
                EmployeeID = dto.EmployeeID,
                OrderDate = dto.OrderDate,
                Status = dto.Status
            };

            // Dodajemy powiązane OrderDetails
            order.OrderDetails = dto.OrderDetails.Select(d => new OrderDetails
            {
                ProductID = d.ProductID,
                UnitPrice = d.UnitPrice,
                Quantity = d.Quantity,
                Discount = d.DiscountID, // Rzutowanie int -> decimal, zależnie od logiki
            }).ToList();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Opcjonalnie wczytujemy nawigacje (Customer, Employee, Product)
            await _context.Entry(order).Reference(o => o.Customer).LoadAsync();
            await _context.Entry(order).Reference(o => o.Employee).LoadAsync();
            foreach (var od in order.OrderDetails)
            {
                await _context.Entry(od).Reference(x => x.Product).LoadAsync();
            }

            // Mapujemy do DTO, aby zwrócić aktualne dane (z nowym OrderID itp.)
            var resultDto = MapOrderToDto(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderID }, resultDto);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto dto)
        {
            if (id != dto.OrderID)
            {
                return BadRequest("Order ID in path does not match DTO");
            }

            // Szukamy istniejącego zamówienia
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Aktualizujemy podstawowe pola
            order.CustomerID = dto.CustomerID;
            order.EmployeeID = dto.EmployeeID;
            order.OrderDate = dto.OrderDate;
            order.Status = dto.Status;

            // Usuwamy stare OrderDetails i dodajemy nowe (proste podejście)
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            order.OrderDetails.Clear();

            foreach (var d in dto.OrderDetails)
            {
                var detail = new OrderDetails
                {
                    ProductID = d.ProductID,
                    UnitPrice = d.UnitPrice,
                    Quantity = d.Quantity,
                    Discount = d.DiscountID
                };
                order.OrderDetails.Add(detail);
            }

            // Oznaczamy Order jako zmodyfikowany
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }

        // ──────────────────────────────────────────────────────────────────────────
        // ───────────────  MAPOWANIE encji <-> DTO  ─────────────────────────────
        // ──────────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Zamienia encję Orders na OrderDto (wraz z OrderDetails).
        /// </summary>
        private OrderDto MapOrderToDto(Orders order)
        {
            var dto = new OrderDto
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerName = order.Customer?.FirstName ?? "",
                EmployeeName = order.Employee?.FirstName ?? "",
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    OrderDetailID = od.OrderDetailsId,
                    ProductID = od.ProductID,
                    ProductName = od.Product?.ProductName ?? "",
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    // Zakładamy, że Discount w bazie to decimal, a w DTO jest int
                    // Poniżej rzutowanie decimal -> int (lub inna logika)
                    DiscountID = (int)od.Discount,
                    DiscountName = od.Discount > 0
                        ? $"Discount {od.Discount}%"
                        : "No discount"
                }).ToList()
            };

            return dto;
        }
    }
}
