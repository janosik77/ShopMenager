using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts; // <-- Zależnie od struktury twojego projektu

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
            // Ładujemy zamówienia wraz z powiązaniami
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Discount)
                .ToListAsync();

            // Mapujemy encje -> DTO
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
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Discount)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            return MapOrderToDto(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto dto)
        {
            // Tworzymy encję Orders
            var order = new Orders
            {
                CustomerId = dto.CustomerID,
                EmployeeId = dto.EmployeeID,
                OrderDate = dto.OrderDate,
                Status = dto.Status
            };

            // Dodajemy powiązane OrderDetails
            order.OrderDetails = dto.OrderDetails.Select(d => new OrderDetails
            {
                ProductId = d.ProductID,
                UnitPrice = d.UnitPrice,
                Quantity = d.Quantity,
                DiscountId = d.DiscountID == 0 ? null : d.DiscountID // null jeśli 0
            }).ToList();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Opcjonalnie wczytujemy nawigacje, by zwrócić aktualne dane
            await _context.Entry(order).Reference(o => o.Customer).LoadAsync();
            await _context.Entry(order).Reference(o => o.Employee).LoadAsync();
            foreach (var od in order.OrderDetails)
            {
                await _context.Entry(od).Reference(x => x.Product).LoadAsync();
                await _context.Entry(od).Reference(x => x.Discount).LoadAsync();
            }

            // Mapujemy do DTO
            var resultDto = MapOrderToDto(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, resultDto);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto dto)
        {
            if (id != dto.OrderID)
                return BadRequest("Order ID in path does not match DTO");

            // Szukamy istniejącego zamówienia
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            // Aktualizujemy podstawowe pola
            order.CustomerId = dto.CustomerID;
            order.EmployeeId = dto.EmployeeID;
            order.OrderDate = dto.OrderDate;
            order.Status = dto.Status;

            // Usuwamy stare OrderDetails i dodajemy nowe (proste podejście)
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            order.OrderDetails.Clear();

            foreach (var d in dto.OrderDetails)
            {
                var detail = new OrderDetails
                {
                    ProductId = d.ProductID,
                    UnitPrice = d.UnitPrice,
                    Quantity = d.Quantity,
                    DiscountId = d.DiscountID == 0 ? null : d.DiscountID
                };
                order.OrderDetails.Add(detail);
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

 
        // MAPOWANIE encji -> DTO
       

        private OrderDto MapOrderToDto(Orders order)
        {
            var dto = new OrderDto
            {
                OrderID = order.OrderId,
                CustomerID = order.CustomerId,
                EmployeeID = order.EmployeeId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerName = order.Customer?.FirstName + " " + order.Customer?.LastName ?? "",
                EmployeeName = order.Employee?.FirstName ?? "",
                OrderDetails = order.OrderDetails.Select(od =>
                {
                    var discountName = od.Discount != null
                        ? od.Discount.DiscountName
                        : null;

                    return new OrderDetailDto
                    {
                        OrderDetailID = od.OrderDetailsId,
                        ProductID = od.ProductId,
                        ProductName = od.Product?.ProductName ?? "",
                        UnitPrice = od.UnitPrice,
                        Quantity = od.Quantity,
                        DiscountID = od.DiscountId ?? 0, // 0 jeśli null
                        DiscountPerc = od.Discount.DiscountRate,
                        Total = BuissnesLogic.BuissnesMath.CalculateTotal(od.Quantity,od.UnitPrice, od.Discount.DiscountRate)
                    };
                }).ToList()
            };

            return dto;
        }
    }
}
