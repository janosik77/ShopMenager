namespace RestApiShopmenager.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethodName { get; set; }
        public required int PaymentMethodID { get; set; }
        public int PaymentStatusID { get; set; }
        public string? PaymentStatusName { get; set; }

    }
}
