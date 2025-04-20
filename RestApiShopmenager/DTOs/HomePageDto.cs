using RestApiShopmenager.BuissnesLogic;

namespace RestApiShopmenager.DTOs
{
    public class HomePageDto
    {
        public int TotalCustomers { get; set; }
        public int PendingOrders { get; set; }
        public int CanceledOrders { get; set; }
        public int ComplitedOrders { get; set; }
        public decimal TotalIncome { get; set; }
        public Dictionary<string, int> OrderStatusCounts { get; set; }
        public Dictionary<string, decimal> PaymentStatusSums { get; set; }
        public List<BestCustomer> TopCustomers { get; set; }
    }
}
