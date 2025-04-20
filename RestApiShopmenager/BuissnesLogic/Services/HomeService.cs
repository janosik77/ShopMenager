using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models.Contexts;


namespace RestApiShopmenager.BuissnesLogic.Services
{
    public class HomeService : IHomeService
    {
        private readonly CompanyContext _context;

        public HomeService(CompanyContext context)
        {
            _context = context;
        }

        public async Task<HomePageDto> GetDashboardAsync()
        {
            var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
            var totalCust = await _context.Customers.CountAsync();

            var pendingAll = _context.Orders == null ? 0 : await _context.Orders.CountAsync(o => o.Status == "pending");
            var canceledAll = _context.Orders == null ? 0 : await _context.Orders.CountAsync(o => o.Status == "canceled");
            var completedAll = _context.Orders == null ? 0 : await _context.Orders.CountAsync(o => o.Status == "completed");

            // Słownik zamówień ostatni miesiąc 
            var lastMonthOrders = await _context.Orders
                .Where(o => o.OrderDate >= oneMonthAgo)
                .GroupBy(o => o.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count());

            var lastMonthPayments = new Dictionary<string, decimal>(); ;

            // Słownik sum płatności 
            if (_context.Payments != null)
            {
                 lastMonthPayments = await _context.Payments
                    .Where(p => p.PaymentDate >= oneMonthAgo)
                    .GroupBy(p => p.PaymentStatus.StatusName)       
                    .ToDictionaryAsync(
                        g => g.Key,                               
                        g => g.Sum(p => p.Amount)                  
                    );
            }

            // Top 3 klientów wg wartości zamówień
            var top3 = await _context.OrderDetails
                        .Include(od => od.Order)
                            .ThenInclude(o => o.Customer)
                        .GroupBy(od => new
                        {
                            od.Order.CustomerId,
                            od.Order.Customer.FirstName,
                            od.Order.Customer.LastName
                        })
                        .Select(g => new BestCustomer
                        {
                            CustomerId = g.Key.CustomerId,
                            Name = $"{g.Key.FirstName} {g.Key.LastName}",
                            TotalOrderValue = g.Sum(od => od.Quantity * od.UnitPrice)
                        })
                        .OrderByDescending(b => b.TotalOrderValue)
                        .Take(3)
                        .ToListAsync();

            // Całkowity przychód
            var totalIncome = await _context.OrderDetails.SumAsync(od => od.Quantity * od.UnitPrice);

            return new HomePageDto
            {
                TotalCustomers = totalCust,
                PendingOrders = pendingAll,
                CanceledOrders = canceledAll,
                ComplitedOrders = completedAll,
                TotalIncome = totalIncome,
                OrderStatusCounts = lastMonthOrders,
                PaymentStatusSums = lastMonthPayments,
                TopCustomers = top3
            };
        }
    }
}
